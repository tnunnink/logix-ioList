﻿using System.Collections.Generic;
using ioList.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// ReSharper disable StringLiteralTypo

namespace ioList.Data.Configurations
{
    public class CardTypeConfiguration : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.ToTable(nameof(CardType)).HasKey(x => x.Id);

            builder.Property(x => x.ProductId).IsRequired();

            builder.HasData(new List<CardType>
            {
                new(1, 0, "Generic Device(deprecated for new devices)"),
                new(2, 1, "Control Station"),
                new(3, 2, "AC Drive Device"),
                new(4, 3, "Motor Overload"),
                new(5, 4, "Limit Switch"),
                new(6, 5, "Inductive Proximity Switch"),
                new(7, 6, "Photoelectric Sensor"),
                new(8, 7, "General Purpose Discrete I/O"),
                new(9, 8, "Encoder"),
                new(10, 9, "Resolver"),
                new(11, 10, "General Purpose Analog I/O"),
                new(12, 11, "Unknown Device Type"),
                new(13, 12, "Communications Adapter"),
                new(14, 13, "Barcode Scanner"),
                new(15, 14, "Programmable Logic Controller"),
                new(16, 15, "Unknown Device Type"),
                new(17, 16, "Position Controller"),
                new(18, 17, "Weigh Scale"),
                new(19, 18, "Message Display"),
                new(20, 19, "DC Drive"),
                new(21, 20, "Servo Drives"),
                new(22, 21, "Contactor"),
                new(23, 22, "Motor Starter"),
                new(24, 23, "Softstart Starter"),
                new(25, 24, "Human-Machine Interface"),
                new(26, 25, "Pneumatic Valve(s)"),
                new(27, 26, "Mass Flow Controller"),
                new(28, 27, "Pneumatic Valve(s)"),
                new(29, 28, "Vacuum Pressure Gauge"),
                new(30, 29, "Process Control Valve"),
                new(31, 30, "Residual Gas Analyzer"),
                new(32, 31, "DC Power Generator"),
                new(33, 32, "RF Power Generator"),
                new(34, 33, "Turbomolecular Vacuum Pump"),
                new(35, 34, "Encoder"),
                new(36, 35, "Safety Discrete I/O Device"),
                new(37, 36, "Fluid Flow Controller"),
                new(38, 37, "CIP Motion Drive"),
                new(39, 38, "CompoNet Repeater"),
                new(40, 39, "Mass Flow Controller, Enhanced"),
                new(41, 999, "Vendor Specific"),
                new(42, 100, "Dodge EZLINK"),
                new(43, 101, "SCANport to DeviceNet"),
                new(44, 102, "1771 Discrete Transfer"),
                new(45, 103, "1771 Block Transfer"),
                new(46, 104, "1771 Block/Discrete Transfer"),
                new(47, 105, "Not a purchasable subassembly"),
                new(48, 106, "Memory Expansion"),
                new(49, 107, "Generic 1794 I/O module"),
                new(50, 108, "Common Interfaces - No Device Object"),
                new(51, 109, "Specialty I/O"),
                new(52, 110, "SCANport to ControlNet"),
                new(53, 111, "SCANport to DeviceNet (Enhanced)"),
                new(54, 112, "Redundancy Product"),
                new(55, 113, "AC Drive - no drive object"),
                new(56, 114, "DC Drive - no drive object"),
                new(57, 115, "Rockwell Automation Miscellaneous"),
                new(58, 116, "1746 Discrete I/O"),
                new(59, 117, "1746 Analog I/O"),
                new(60, 118, "1746 Specialty I/O"),
                new(61, 119, "1769 products without objects"),
                new(62, 120, "DPI to ControlNet"),
                new(63, 121, "DPI to DeviceNet"),
                new(64, 122, "Smart MCC"),
                new(65, 123, "DPI to EtherNet/IP"),
                new(66, 124, "Adapter I/O accessed via proxy"),
                new(67, 125, "High Performance Systems Modules"),
                new(68, 126, "DSI to DeviceNet"),
                new(69, 127, "DSI to EtherNet/IP"),
                new(70, 128, "SCANport to EtherNet/IP"),
                new(71, 129, "DPI to ControlNet (Fiber)"),
                new(72, 130, "(SERVO) Analog Axis Interface Module"),
                new(73, 131, "(SERCOS) Digital Axis Interface Module"),
                new(74, 100, "Rockwell Automation Unspecified"),
                new(75, 101, "Rockwell Automation Unspecified"),
                new(76, 102, "Rockwell Automation Unspecified"),
                new(77, 103, "Rockwell Automation Unspecified"),
                new(78, 104, "Rockwell Automation Unspecified"),
                new(79, 105, "Rockwell Automation Unspecified"),
                new(80, 106, "Rockwell Automation Unspecified"),
                new(81, 107, "Rockwell Automation Unspecified"),
                new(82, 108, "Rockwell Automation Unspecified"),
                new(83, 109, "Rockwell Automation Unspecified"),
                new(84, 110, "Rockwell Automation Unspecified"),
                new(85, 111, "Rockwell Automation Unspecified"),
                new(86, 112, "Rockwell Automation Unspecified"),
                new(87, 113, "Rockwell Automation Unspecified"),
                new(88, 127, "MDI to EtherNet/IP"),
                new(89, 114, "Rockwell Automation Unspecified"),
                new(90, 115, "Rockwell Automation Unspecified"),
                new(91, 132, "DSI to Compact I/O"),
                new(92, 133, "PointBus Motor Starter"),
                new(93, 134, "DPI/SCANport to Compact I/O"),
                new(94, 135, "DSI to Modbus/TCP"),
                new(95, 136, "DSI to ControlNet"),
                new(96, 137, "Guard PLC Safety Scanner"),
                new(97, 138, "Safety Controller"),
                new(98, 139, "RFID Scanner"),
                new(99, 140, "PowerFlex 750-Series via ControlNet"),
                new(100, 141, "PowerFlex 750-Series via DeviceNet"),
                new(101, 142, "PowerFlex 750-Series via EtherNet"),
                new(102, 143, "PowerFlex 750-Series via Embedded EtherNet/IP"),
                new(103, 144, "Information Appliance"),
                new(104, 100, "Dodge EZLINK"),
                new(105, 40, "CIP Modbus Device"),
                new(106, 41, "CIP Modbus Translator"),
                new(107, 42, "Safety Analog I/O Device"),
                new(108, 43, "Generic Device(keyable)"),
                new(109, 50, "ControlNet Physical Layer Component"),
                new(110, 44, "Managed Ethernet Switch"),
                new(111, 45, "CIP Motion Safety Drive Device"),
                new(112, 46, "Safety Drive Device"),
                new(115, 47, "CIP Motion Encoder"),
                new(116, 48, "CIP Motion Converter"),
                new(117, 49, "CIP Motion I/O"),
                new(118, 200, "Embedded Component"),
                new(119, 146, "PowerMonitor 5000 Series"),
                new(120, 149, "HS - DSI to DeviceNet"),
                new(121, 150, "HS - DSI to EtherNet/IP"),
                new(122, 151, "HS - DSI to Dual Port EtherNet/IP"),
                new(123, 152, "DPI to Dual Port EtherNet/IP"),
                new(124, 153, "Time Master"),
                new(125, 154, "Small Safety Controller"),
                new(126, 155, "IO-Link Master Device"),
                new(127, 145, "Safety Analog I/O"),
                new(128, 147, "UPS (Uninterruptible Power Supply)"),
                new(129, 148, "HS - DSI to ControlNet"),
                new(130, 156, "Safety Light Curtain"),
                new(131, 157, "Guard Locking w. Access Control"),
                new(132, 160, "48CR Code Reader"),
                new(139, 126, "MDI to DeviceNet"),
                new(140, 132, "MDI to Compact I/O"),
                new(141, 134, "DPI to Compact I/O"),
                new(142, 135, "MDI to Modbus/TCP"),
                new(143, 136, "MDI to ControlNet"),
                new(144, 51, "Unknown Device Type"),
                new(145, 52, "Unknown Device Type"),
                new(146, 53, "Unknown Device Type"),
                new(147, 54, "Unknown Device Type"),
                new(148, 55, "Unknown Device Type"),
                new(149, 56, "Unknown Device Type"),
                new(150, 57, "Unknown Device Type"),
                new(151, 58, "Unknown Device Type"),
                new(152, 59, "Unknown Device Type"),
                new(153, 60, "Unknown Device Type"),
                new(154, 61, "Unknown Device Type"),
                new(155, 62, "Unknown Device Type"),
                new(156, 63, "Unknown Device Type"),
                new(157, 65, "Unknown Device Type"),
                new(158, 64, "Unknown Device Type"),
                new(159, 66, "Unknown Device Type"),
                new(160, 67, "Unknown Device Type"),
                new(161, 68, "Unknown Device Type"),
                new(162, 69, "Unknown Device Type"),
                new(163, 70, "Unknown Device Type"),
                new(164, 71, "Unknown Device Type"),
                new(165, 72, "Unknown Device Type"),
                new(166, 73, "Unknown Device Type"),
                new(167, 74, "Unknown Device Type"),
                new(168, 75, "Unknown Device Type"),
                new(169, 76, "Unknown Device Type"),
                new(170, 77, "Unknown Device Type"),
                new(171, 78, "Unknown Device Type"),
                new(172, 79, "Unknown Device Type"),
                new(173, 80, "Unknown Device Type"),
                new(174, 81, "Unknown Device Type"),
                new(175, 82, "Unknown Device Type"),
                new(176, 83, "Unknown Device Type"),
                new(177, 84, "Unknown Device Type"),
                new(178, 85, "Unknown Device Type"),
                new(179, 86, "Unknown Device Type"),
                new(180, 87, "Unknown Device Type"),
                new(181, 88, "Unknown Device Type"),
                new(182, 89, "Unknown Device Type"),
                new(183, 90, "Unknown Device Type"),
                new(184, 91, "Unknown Device Type"),
                new(185, 92, "Unknown Device Type"),
                new(186, 93, "Unknown Device Type"),
                new(187, 94, "Unknown Device Type"),
                new(188, 95, "Unknown Device Type"),
                new(189, 96, "Unknown Device Type"),
                new(190, 97, "Unknown Device Type"),
                new(191, 98, "Unknown Device Type"),
                new(192, 99, "Unknown Device Type"),
            });
        }
    }
}