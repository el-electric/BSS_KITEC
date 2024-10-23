using DrakeUI.Framework;
using EL_BSS.Cycle;
using EL_DC_Charger.ocpp.ver16.comm;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IdentityModel;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EL_BSS.Model;

namespace EL_BSS.Serial
{
    public class sp_Slave
    {
        public static SerialPort serial;
        private static List<byte> mReceive_Data = new List<byte>();
        public static CsSlotchargingManager[] CsSlotchargingManager;

        public static bool Open(string PortName)
        {
            CsSlotchargingManager = new CsSlotchargingManager[8];

            for (int i = 1; i <= 8; i++)
            {
                CsSlotchargingManager[i - 1] = new CsSlotchargingManager(i);
            }

            try
            {
                serial = new SerialPort();

                serial.PortName = PortName;
                serial.BaudRate = 115200;
                serial.Parity = Parity.None;
                serial.DataBits = 8;
                serial.StopBits = StopBits.One;
                serial.Handshake = Handshake.None;

                serial.DataReceived += Comport1_DataReceived;
                serial.Open();

                Model.getInstance().isOpen_Slave = true;
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public static void Close()
        {
            CsSlotchargingManager = null;
            serial.Close();
        }
        private static void Comport1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serial.BytesToRead;
            byte[] receivedData = new byte[bytesToRead];
            serial.Read(receivedData, 0, bytesToRead);

            // processData 함수에 전체 바이트 배열을 한 번에 전달
            //await Task.Run(() => processData(receivedData));
            processData(receivedData);
        }

        private static void processData(byte[] data)
        {
            // 수신된 데이터를 버퍼에 추가
            mReceive_Data.AddRange(data);
            // Console.WriteLine(BitConverter.ToString(data).Replace("-", "") + " LEN " + data.Length + " COUNT : " + _count++);
            while (true)
            {
                int startIndex = mReceive_Data.IndexOf(0xfe); // STX
                if (!Model.getInstance().FirmwareUpdate)
                {
                    int packetLength = 108; // 패킷의 길이

                    try
                    {
                        // STX가 있고, 충분한 길이의 데이터가 있는지 확인
                        if (startIndex != -1 && mReceive_Data.Count >= startIndex + packetLength)
                        {
                            if (mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                            {
                                byte[] packet = mReceive_Data.GetRange(startIndex, packetLength).ToArray();

                                // 패킷 처리
                                HandlePacket(packet);

                                // 처리된 데이터 제거
                                mReceive_Data.RemoveRange(0, startIndex + packetLength);


                                // 버퍼에 더 이상 데이터가 없으면 반복 중단
                                if (mReceive_Data.Count == 0)
                                {
                                    break;
                                }
                            }
                            else if (!mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                            {
                                mReceive_Data.RemoveRange(0, startIndex + packetLength);
                            }
                        }
                        else
                        {
                            // 완전한 패킷이 아직 도착하지 않았으면, 루프 탈출
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        CsUtil.WriteLog("슬레이브 : " + ex.Message + " " + ex.InnerException, "ERROR");
                        mReceive_Data.RemoveRange(0, startIndex + packetLength);
                    }
                }
                else if (Model.getInstance().FirmwareUpdate)
                {
                    int packetLength = 20; // 패킷의 길이

                    // STX가 있고, 충분한 길이의 데이터가 있는지 확인
                    if (startIndex != -1 && mReceive_Data.Count >= startIndex + 20)  // f1을 받을때
                    {
                        if (mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                        {
                            byte[] packet = mReceive_Data.GetRange(startIndex, packetLength).ToArray();

                            // 패킷 처리
                            HandlePacket_f1(packet);

                            // 처리된 데이터 제거
                            mReceive_Data.RemoveRange(0, startIndex + packetLength);

                            // 버퍼에 더 이상 데이터가 없으면 반복 중단
                            if (mReceive_Data.Count == 0)
                            {
                                break;
                            }
                        }
                        else if (!mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                        {
                            packetLength = 27;
                            if (startIndex != -1 && mReceive_Data.Count >= startIndex + 27)  // f0를 받을때
                            {
                                if (mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                                {
                                    byte[] packet = mReceive_Data.GetRange(startIndex, packetLength).ToArray();

                                    // 패킷 처리
                                    HandlePacket_f0(packet);

                                    // 처리된 데이터 제거
                                    mReceive_Data.RemoveRange(0, startIndex + packetLength);

                                    // 버퍼에 더 이상 데이터가 없으면 반복 중단
                                    if (mReceive_Data.Count == 0)
                                    {
                                        break;
                                    }
                                }
                                else if (!mReceive_Data[startIndex + packetLength - 1].Equals(0xff))
                                {
                                    mReceive_Data.RemoveRange(0, startIndex + packetLength);
                                }
                            }
                        }
                    }
                    else
                    {
                        // 완전한 패킷이 아직 도착하지 않았으면, 루프 탈출
                        break;
                    }
                }
            }
        }

        static int slaveId = 0;
        static int masterId = 0;
        static int idx = 0;
        static bool test = false;
        static byte[] temp = new byte[2];
        static int _count = 0;
        private static void HandlePacket(byte[] packet)
        {
            //Console.WriteLine(BitConverter.ToString(packet).Replace("-", "") + " LEN " + packet.Length + " COUNT : " + _count++);


            masterId = packet[4];
            slaveId = packet[5];


            if (masterId == 2)
                idx = slaveId + 4;
            else
                idx = slaveId;

            //Model.getInstance().list_SlaveRecv[slaveId].isRecv = true;

            ///////////////// TEMP LOG ///////////////
            TimeSpan difference = DateTime.Now - Model.getInstance().list_SlaveDataRecvDatetime[idx - 1];
            CsUtil.WriteLog("," + idx + ", Receive TERM : " + difference.ToString(@"hh\:mm\:ss\.fff"), "SLAVE");
            //////////////////////////////////////////

            Model.getInstance().list_SlaveDataRecvDatetime[idx - 1] = DateTime.Now;




            Model.getInstance().list_SlaveRecv[idx - 1].BatterArrive = EL_Manager_Conversion.getFlagByByteArray(packet[17], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].isDoor = EL_Manager_Conversion.getFlagByByteArray(packet[18], 6);

            if (Model.getInstance().list_SlaveRecv[idx - 1].isDoor)
            {
                Model.getInstance().list_SlaveSend[idx - 1].doorOpen = false;
                Model.getInstance().list_SlaveRecv[idx - 1].dt_DoorOpening_Time = DateTime.Now;
            }

            Model.getInstance().list_SlaveRecv[idx - 1].SeqNum = packet[19];
            Model.getInstance().list_SlaveRecv[idx - 1].PowerPackStatus = EL_Manager_Conversion.getFlagByByteArray(packet[20], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].PowerPackVoltage = EL_Manager_Conversion.getInt_2Byte(packet[21], packet[22]);
            Model.getInstance().list_SlaveRecv[idx - 1].PowerPackWattage = EL_Manager_Conversion.getInt_2Byte(packet[23], packet[24]);
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryCurrentVoltage = EL_Manager_Conversion.getInt_2Byte(packet[25], packet[26]);
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryCurrentWattage = EL_Manager_Conversion.getInt_2Byte_with_minus(packet[27], packet[28]);
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryRequestVoltage = EL_Manager_Conversion.getInt_2Byte(packet[29], packet[30]);

            if (Model.getInstance().list_SlaveRecv[idx - 1].BatteryRequestVoltage == 0)
            {
            }
            else if ((Model.getInstance().list_SlaveRecv[idx - 1].BatteryRequestVoltage / 10) > 65)
            {
                Model.getInstance().list_SlaveRecv[idx - 1].Check_BatteryVoltage_Type = 72;
            }
            else if ((Model.getInstance().list_SlaveRecv[idx - 1].BatteryRequestVoltage / 10) < 65)
            {
                Model.getInstance().list_SlaveRecv[idx - 1].Check_BatteryVoltage_Type = 48;
            }
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryRequestWattage = EL_Manager_Conversion.getInt_2Byte(packet[31], packet[32]);
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryMaxTemper = (EL_Manager_Conversion.getInt_2Byte(packet[33], packet[34]) - 40);
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryMinTemper = (EL_Manager_Conversion.getInt_2Byte(packet[35], packet[36]) - 40);

            if (Model.getInstance().list_SlaveRecv[idx - 1].WAKEUP_Signal)
            {
                Model.getInstance().list_SlaveRecv[idx - 1].BatteryMaxTemper = (EL_Manager_Conversion.getInt_2Byte(packet[33], packet[34]) - 40);
                Model.getInstance().list_SlaveRecv[idx - 1].BatteryMinTemper = (EL_Manager_Conversion.getInt_2Byte(packet[35], packet[36]) - 40);
            }
            else
            {
                Model.getInstance().list_SlaveRecv[idx - 1].BatteryMaxTemper = EL_Manager_Conversion.getInt_2Byte(packet[33], packet[34]);
                Model.getInstance().list_SlaveRecv[idx - 1].BatteryMinTemper = EL_Manager_Conversion.getInt_2Byte(packet[35], packet[36]);
            }


            Model.getInstance().list_SlaveRecv[idx - 1].ProcessStatus = EL_Manager_Conversion.getInt(packet[37]);
            Model.getInstance().list_SlaveRecv[idx - 1].ErrorCode = EL_Manager_Conversion.getInt_2Byte(packet[38], packet[39]);
            Model.getInstance().list_SlaveRecv[idx - 1].SOC = EL_Manager_Conversion.getInt(packet[40]);

            /*if (EL_Manager_Conversion.getInt(packet[40]) >= 99)
            {
                Model.getInstance().list_SlaveRecv[idx - 1].SOC = 100;
            }
            else
            {
                Model.getInstance().list_SlaveRecv[idx - 1].SOC = EL_Manager_Conversion.getInt(packet[40]) + 1;
            }*/

            Model.getInstance().list_SlaveRecv[idx - 1].SOC = EL_Manager_Conversion.getInt(packet[40]);

            Model.getInstance().list_SlaveRecv[idx - 1].SOH = EL_Manager_Conversion.getInt(packet[41]);
            Model.getInstance().list_SlaveRecv[idx - 1].RemainTime = EL_Manager_Conversion.getInt_2Byte(packet[42], packet[43]);

            Model.getInstance().list_SlaveRecv[idx - 1].firmWareVersion_Major = EL_Manager_Conversion.getInt(packet[44]);
            Model.getInstance().list_SlaveRecv[idx - 1].firmWareVersion_Minor = EL_Manager_Conversion.getInt(packet[45]);
            Model.getInstance().list_SlaveRecv[idx - 1].firmWareVersion_Patch = EL_Manager_Conversion.getInt(packet[46]);
            Model.getInstance().list_SlaveRecv[idx - 1].firmWareVersion = EL_Manager_Conversion.getInt(packet[44]).ToString() + "." + EL_Manager_Conversion.getInt(packet[45]).ToString() + "." + EL_Manager_Conversion.getInt(packet[46]).ToString();
            Model.getInstance().list_SlaveRecv[idx - 1].protocolVersion_Major = EL_Manager_Conversion.getInt(packet[47]);
            Model.getInstance().list_SlaveRecv[idx - 1].protocolVersion_Minor = EL_Manager_Conversion.getInt(packet[48]);
            Model.getInstance().list_SlaveRecv[idx - 1].protocolVersion_Patch = EL_Manager_Conversion.getInt(packet[49]);

            temp[0] = packet[50];
            temp[1] = packet[51];
            Model.getInstance().list_SlaveRecv[idx - 1].BatteryType = EL_Manager_Conversion.ByteArrayToString(temp);

            // Model.getInstance().list_SlaveRecv[idx - 1].rowVoltage = EL_Manager_Conversion.getFlagByByteArray(packet[52], 7);
           Model.getInstance().list_SlaveRecv[idx - 1].rowVoltage = EL_Manager_Conversion.getFlagByByteArray(packet[52], 7); 

            Model.getInstance().list_SlaveRecv[idx - 1].highVoltage = EL_Manager_Conversion.getFlagByByteArray(packet[52], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].packLowVoltage = EL_Manager_Conversion.getFlagByByteArray(packet[52], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].packHighVoltage = EL_Manager_Conversion.getFlagByByteArray(packet[52], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].cellRecycleOverCharging = EL_Manager_Conversion.getFlagByByteArray(packet[52], 3);
            Model.getInstance().list_SlaveRecv[idx - 1].packRecycleOverCharging = EL_Manager_Conversion.getFlagByByteArray(packet[52], 2);
            Model.getInstance().list_SlaveRecv[idx - 1].overDischarge = EL_Manager_Conversion.getFlagByByteArray(packet[52], 1);
            Model.getInstance().list_SlaveRecv[idx - 1].overCharging = EL_Manager_Conversion.getFlagByByteArray(packet[52], 0);

            Model.getInstance().list_SlaveRecv[idx - 1].reCycleOverCharging = EL_Manager_Conversion.getFlagByByteArray(packet[53], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].cell_LowTemp = EL_Manager_Conversion.getFlagByByteArray(packet[53], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].cell_HighTemp = EL_Manager_Conversion.getFlagByByteArray(packet[53], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].FET_LowTemp = EL_Manager_Conversion.getFlagByByteArray(packet[53], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].FET_HighTemp = EL_Manager_Conversion.getFlagByByteArray(packet[53], 3);


            Model.getInstance().list_SlaveRecv[idx - 1].lowVoltageProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].highVoltageProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].packLowVoltageProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].packHighVoltageProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].cellRecycleOverChargingProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 3);
            Model.getInstance().list_SlaveRecv[idx - 1].packRecycleOverChargingProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 2);
            Model.getInstance().list_SlaveRecv[idx - 1].overDischargeProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 1);
            Model.getInstance().list_SlaveRecv[idx - 1].overChargingProtection = EL_Manager_Conversion.getFlagByByteArray(packet[54], 0);


            Model.getInstance().list_SlaveRecv[idx - 1].reCycleOverChargingProtection = EL_Manager_Conversion.getFlagByByteArray(packet[55], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].cellLowTempProtection = EL_Manager_Conversion.getFlagByByteArray(packet[55], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].cellHighTempProtection = EL_Manager_Conversion.getFlagByByteArray(packet[55], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].FETLowTempProtection = EL_Manager_Conversion.getFlagByByteArray(packet[55], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].FETHighTempProtection = EL_Manager_Conversion.getFlagByByteArray(packet[55], 3);
            Model.getInstance().list_SlaveRecv[idx - 1].shortProtect = EL_Manager_Conversion.getFlagByByteArray(packet[55], 2);
            Model.getInstance().list_SlaveRecv[idx - 1].VCUError = EL_Manager_Conversion.getFlagByByteArray(packet[55], 1);
            Model.getInstance().list_SlaveRecv[idx - 1].PreChargeError = EL_Manager_Conversion.getFlagByByteArray(packet[55], 0);

            Model.getInstance().list_SlaveRecv[idx - 1].WAKEUP_Signal = EL_Manager_Conversion.getFlagByByteArray(packet[56], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].BMSReadyState = EL_Manager_Conversion.getFlagByByteArray(packet[56], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].VCU_Connect = EL_Manager_Conversion.getFlagByByteArray(packet[56], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].charger_Connect = EL_Manager_Conversion.getFlagByByteArray(packet[56], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].chargeStationConnect = EL_Manager_Conversion.getFlagByByteArray(packet[56], 3);
            Model.getInstance().list_SlaveRecv[idx - 1].discharge_FET_State = EL_Manager_Conversion.getFlagByByteArray(packet[56], 2);
            Model.getInstance().list_SlaveRecv[idx - 1].charge_FET_State = EL_Manager_Conversion.getFlagByByteArray(packet[56], 1);
            Model.getInstance().list_SlaveRecv[idx - 1].FET_ON_State = EL_Manager_Conversion.getFlagByByteArray(packet[56], 0);

            Model.getInstance().list_SlaveRecv[idx - 1].Charge_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].Discharge_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].Regeneration_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].Ready_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].Emergence_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 3);
            Model.getInstance().list_SlaveRecv[idx - 1].Protect_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 2);
            Model.getInstance().list_SlaveRecv[idx - 1].BMS_ERR_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 1);
            Model.getInstance().list_SlaveRecv[idx - 1].Balancing_State = EL_Manager_Conversion.getFlagByByteArray(packet[57], 0);

            Model.getInstance().list_SlaveRecv[idx - 1].ROM_Check = EL_Manager_Conversion.getFlagByByteArray(packet[58], 7);
            Model.getInstance().list_SlaveRecv[idx - 1].RAM_Check = EL_Manager_Conversion.getFlagByByteArray(packet[58], 6);
            Model.getInstance().list_SlaveRecv[idx - 1].Thermistor_Open = EL_Manager_Conversion.getFlagByByteArray(packet[58], 5);
            Model.getInstance().list_SlaveRecv[idx - 1].Thermistor_Short = EL_Manager_Conversion.getFlagByByteArray(packet[58], 4);
            Model.getInstance().list_SlaveRecv[idx - 1].Current_Error = EL_Manager_Conversion.getFlagByByteArray(packet[58], 3);
            Model.getInstance().list_SlaveRecv[idx - 1].FET_Error = EL_Manager_Conversion.getFlagByByteArray(packet[58], 2);
            Model.getInstance().list_SlaveRecv[idx - 1].Cell_Deviation_Error = EL_Manager_Conversion.getFlagByByteArray(packet[58], 1);
            Model.getInstance().list_SlaveRecv[idx - 1].All_Pack_Deviation_Error = EL_Manager_Conversion.getFlagByByteArray(packet[58], 0);

            Model.getInstance().list_SlaveRecv[idx - 1].FET_Temper = (EL_Manager_Conversion.getInt(packet[59]) - 40);

            if (Model.getInstance().list_SlaveRecv[idx - 1].WAKEUP_Signal) { Model.getInstance().list_SlaveRecv[idx - 1].FET_Temper = (EL_Manager_Conversion.getInt(packet[59]) - 40); }
            else { Model.getInstance().list_SlaveRecv[idx - 1].FET_Temper = EL_Manager_Conversion.getInt(packet[59]); }
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_FW_Version = EL_Manager_Conversion.getInt(packet[60]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Model = EL_Manager_Conversion.getInt_2Byte(packet[61], packet[62]);
            Model.getInstance().list_SlaveRecv[idx - 1].Year = EL_Manager_Conversion.getInt(packet[63]);
            Model.getInstance().list_SlaveRecv[idx - 1].Month = EL_Manager_Conversion.getInt(packet[64]);
            Model.getInstance().list_SlaveRecv[idx - 1].Day = EL_Manager_Conversion.getInt(packet[65]);

            Model.getInstance().list_SlaveRecv[idx - 1].Serial_Number = EL_Manager_Conversion.getInt_2Byte(packet[66], packet[67]);

            
                Model.getInstance().list_SlaveRecv[idx - 1].Battery_Slot_Temp = (EL_Manager_Conversion.getInt(packet[68]) - 40);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_High_Voltage = (EL_Manager_Conversion.getdouble_2Byte(packet[69], packet[70]) * 0.05);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Low_Voltage = (EL_Manager_Conversion.getInt_2Byte(packet[71], packet[72]) * 0.05);
            Model.getInstance().list_SlaveRecv[idx - 1].Cell_Belancing_Flag = EL_Manager_Conversion.getInt_2Byte(packet[73], packet[74]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Moduel_Voltage = EL_Manager_Conversion.getInt_2Byte(packet[75], packet[76]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_01 = EL_Manager_Conversion.getInt_2Byte(packet[77], packet[78]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_02 = EL_Manager_Conversion.getInt_2Byte(packet[79], packet[80]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_03 = EL_Manager_Conversion.getInt_2Byte(packet[81], packet[82]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_04 = EL_Manager_Conversion.getInt_2Byte(packet[83], packet[84]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_05 = EL_Manager_Conversion.getInt_2Byte(packet[85], packet[86]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_06 = EL_Manager_Conversion.getInt_2Byte(packet[87], packet[88]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_07 = EL_Manager_Conversion.getInt_2Byte(packet[89], packet[90]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_08 = EL_Manager_Conversion.getInt_2Byte(packet[91], packet[92]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_09 = EL_Manager_Conversion.getInt_2Byte(packet[93], packet[94]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_10 = EL_Manager_Conversion.getInt_2Byte(packet[95], packet[96]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_11 = EL_Manager_Conversion.getInt_2Byte(packet[97], packet[98]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_12 = EL_Manager_Conversion.getInt_2Byte(packet[99], packet[100]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_13 = EL_Manager_Conversion.getInt_2Byte(packet[101], packet[102]);
            Model.getInstance().list_SlaveRecv[idx - 1].Battery_Cell_Vol_14 = EL_Manager_Conversion.getInt_2Byte(packet[103], packet[104]);

            if (Model.getInstance().list_SlaveRecv[idx - 1].Cell_Deviation_Error || Model.getInstance().list_SlaveRecv[idx - 1].All_Pack_Deviation_Error)
            {

            }

            if (Model.getInstance().Send_bootnotification)
            {
                if (Model.getInstance().Check_statusnotification[idx - 1] == null)
                {
                    Model.getInstance().Check_statusnotification[idx - 1] = Check_Status(idx - 1);
                    Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(idx - 1, Model.getInstance().Check_statusnotification[idx - 1]);
                }
                else
                {
                    if (Model.getInstance().Check_statusnotification[idx - 1] != Check_Status(idx - 1))
                    {
                        Model.getInstance().Check_statusnotification[idx - 1] = Check_Status(idx - 1);
                        Model.getInstance().oCPP_Comm_SendMgr.sendOCPP_CP_Req_StatusNotification_for_Check_Battery(idx - 1, Model.getInstance().Check_statusnotification[idx - 1]);
                    }
                }
            }

            CsSlotchargingManager[idx - 1].Slot_Charging_Manage();
        }

        public static void Stop_Charging_all_Slot()
        {
            for (int i = 0; i < 8; i++)
            {
                Model.getInstance().list_SlaveSend[i].BatteryOutput = false;
            }
        }

        public static bool Check_able_battery_slot()
        {
            int check_slot_Count = 0;
            int check_Retreive_slot_Count = 0;
            int check_lent_Slot_Count = 0;

            for (int i = 1; i <= 8; i++)
            {
                if (Model.getInstance().list_SlaveRecv[i - 1].BatterArrive &&
                    Model.getInstance().list_SlaveRecv[i - 1].SOC == 100 &&
                    Model.getInstance().list_SlaveRecv[i - 1].Check_BatteryVoltage_Type == Model.getInstance().Authorize.batteryType &&
                    check_Retreive_slot_Count != 2
                    )
                {
                    check_Retreive_slot_Count++;
                    Model.getInstance().Retreive_slot[check_Retreive_slot_Count - 1] = i;
                    Model.getInstance().list_SlaveRecv[i - 1].isSequence = true;

                }
                else if (!Model.getInstance().list_SlaveRecv[i - 1].BatterArrive && check_lent_Slot_Count != 2)
                {
                    check_lent_Slot_Count++;
                    Model.getInstance().Lent_slot[check_lent_Slot_Count - 1] = i;
                    Model.getInstance().list_SlaveRecv[i - 1].isSequence = true;
                }

                if (check_Retreive_slot_Count == 2 && check_lent_Slot_Count == 2)
                {
                    return true;
                }
            }

            return false;
        }

        private static string Check_Status(int i)
        {
            if (Model.getInstance().list_SlaveRecv[i].ProcessStatus == 100 && Model.getInstance().list_SlaveRecv[i].BatterArrive)
            {
                return enumData.Charging.ToString();
            }
            if (Model.getInstance().list_SlaveRecv[i].Error_Occured)
            {
                return enumData.ERROR.ToString();
            }
            else if (Model.getInstance().Check_statusnotification[i] == enumData.Charging.ToString() && Model.getInstance().list_SlaveRecv[i].SOC == 100 && Model.getInstance().list_SlaveRecv[i].BatterArrive)
            {
                return enumData.Finishing.ToString();
            }
            else if (Model.getInstance().list_SlaveRecv[i].BatterArrive && Model.getInstance().list_SlaveRecv[i].WAKEUP_Signal)
            {
                return enumData.Preparing.ToString();
            }
            else
            {
                return enumData.Empty.ToString();
            }
        }

        private static void HandlePacket_f1(byte[] packet)
        {
            Model.getInstance().PWUpdate_Receive_MasterID = packet[1];
            Model.getInstance().PWUpdate_Receive_SlaveID = packet[2];
            int JMT = 0;
            /*Console.WriteLine(BitConverter.ToString(packet) + " LEN " + packet.Length);*/

            Model.getInstance().PWUpdate_Send_Flag = packet[9];

            if (Model.getInstance().PWUpdate_Send_Flag == 2)
            {
                if (Model.getInstance().Auto_Update)
                {
                    if (Model.getInstance().PWUpdate_Receive_MasterID == 1)
                    {
                        if (Model.getInstance().PWUpdate_Receive_SlaveID < 5)
                        {
                            Model.getInstance().PWUpdate_SlaveID++;
                        }
                        else
                        {
                            Model.getInstance().PWUpdate_MasterID = 2;
                            Model.getInstance().PWUpdate_SlaveID = 0;
                        }
                    }
                    else if (Model.getInstance().PWUpdate_Receive_MasterID == 2)
                    {
                        if (Model.getInstance().PWUpdate_Receive_SlaveID < 5)
                        {
                            Model.getInstance().PWUpdate_SlaveID++;
                        }
                        else
                        {
                            Model.getInstance().FirmwareUpdate = false;
                        }
                    }

                    byte[] bytes = Model.getInstance().makeMaserPacket(1);
                    sp_Master.Write(bytes);
                }
                else
                {
                    JMT = 2;
                    Console.WriteLine("SlaveJMT is 2");
                    Model.getInstance().FirmwareUpdate = false;
                }
            }
            else if (Model.getInstance().PWUpdate_Send_Flag == 1)
            {
                JMT = 1;
                Console.WriteLine("SlaveJMT is 1");
            }

            Model.getInstance().PWUpdate_Jump_Flag = packet[10];

            Model.getInstance().Binary_Data_Seq = EL_Manager_Conversion.getInt_2Byte(packet[14], packet[15]);

            if (packet[16] == 0x06)
            {
                Model.getInstance().FirmWareisAck = true;
            }
            else if (packet[16] == 0x15)
            {
                Model.getInstance().FirmWareisNak = true;
            }
        }

        private static void HandlePacket_f0(byte[] packet)
        {
            Model.getInstance().boot_Version_Major = packet[9];
            Model.getInstance().boot_Version_Minor = packet[10];
            Model.getInstance().boot_Version_Patch = packet[11];

            Model.getInstance().app1_Version_Major = packet[12];
            Model.getInstance().app1_Version_Minor = packet[13];
            Model.getInstance().app1_Version_Patch = packet[14];

            Model.getInstance().app2_Version_Major = packet[15];
            Model.getInstance().app2_Version_Minor = packet[16];
            Model.getInstance().app2_Version_Patch = packet[17];

            Model.getInstance().FirmwareUpdate = false;
        }

        public static void Write(byte[] bytes)
        {
            serial.Write(bytes, 0, bytes.Length);   
        }

        /*public static void Check_Over_V_C()
        {
            if (Model.getInstance().list_SlaveRecv[])
        }*/
    }
}
