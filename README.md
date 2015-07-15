## Evil Network Connection WMI Provider
- Returns Netstat like Information when queried
- Contains a RunPs Method that executes arbitrary PowerShell as System

## Install Provider:
```
- Download and unzip project
- Open administrator prompt
- cd to directory containing EvilNetConnectionWMIProvider.dll

PS C:\Windows\system32> cd <downloadpath>\EvilNetConnectionWMIProvider-master\EvilNetConnectionWMIProvider\bin\Debug
PS <downloadpath>\EvilNetConnectionWMIProvider-master\EvilNetConnectionWMIProvider\bin\Debug> InstallUtil.exe /i EvilNetConnectionWMIProvider.dll
```

## Uninstall Provider
```
PS C:\Windows\system32> cd <downloadpath>\EvilNetConnectionWMIProvider-master\EvilNetConnectionWMIProvider\bin\Debug
PS <downloadpath>\EvilNetConnectionWMIProvider-master\EvilNetConnectionWMIProvider\bin\Debug> Uninstall "InstallUtil.exe /u EvilNetConnectionWMIProvider.dll"
```

## Query Network Connections (netstat functionality):
```
PS C:\Windows\system32> Get-WMIObject Win32_NetConnection | select LocalAddress, LocalPort, RemoteAddress, RemotePort, Protocol, State | ft -AutoSize

LocalAddress LocalPort RemoteAddress  RemotePort Protocol State
------------ --------- -------------  ---------- -------- -----
127.0.0.1         3369 127.0.0.1           19872 TCP      Established
127.0.0.1         3374 127.0.0.1            3375 TCP      Established
127.0.0.1         3375 127.0.0.1            3374 TCP      Established
127.0.0.1        19872 127.0.0.1            3369 TCP      Established
192.168.1.18     14040 65.52.0.51           5671 TCP      Established
192.168.1.18     14047 192.30.252.91         443 TCP      Established
192.168.1.18     14061 157.56.100.57         443 TCP      Established
192.168.1.18     14091 65.52.0.51           5671 TCP      Established
192.168.1.18     14099 54.230.49.116         443 TCP      CloseWait
192.168.1.18     14141 108.160.170.35        443 TCP      Established
0.0.0.0            135                         0 TCP      LISTENING
0.0.0.0            445                         0 TCP      LISTENING
0.0.0.0           1025                         0 TCP      LISTENING
0.0.0.0           1026                         0 TCP      LISTENING
0.0.0.0           1027                         0 TCP      LISTENING
0.0.0.0           1028                         0 TCP      LISTENING
0.0.0.0           1029                         0 TCP      LISTENING
0.0.0.0           1030                         0 TCP      LISTENING
0.0.0.0           5357                         0 TCP      LISTENING
0.0.0.0          17500                         0 TCP      LISTENING
0.0.0.0          47001                         0 TCP      LISTENING
127.0.0.1         2738                         0 TCP      LISTENING
127.0.0.1         5860                         0 TCP      LISTENING
127.0.0.1         5861                         0 TCP      LISTENING
127.0.0.1        13838                         0 TCP      LISTENING
127.0.0.1        14092                         0 TCP      LISTENING
127.0.0.1        14093                         0 TCP      LISTENING
127.0.0.1        17600                         0 TCP      LISTENING
127.0.0.1        17603                         0 TCP      LISTENING
192.168.1.18       139                         0 TCP      LISTENING
0.0.0.0           3702                         0 UDP      LISTENING
0.0.0.0           3702                         0 UDP      LISTENING
0.0.0.0           5355                         0 UDP      LISTENING
0.0.0.0          17500                         0 UDP      LISTENING
0.0.0.0          54056                         0 UDP      LISTENING
127.0.0.1         1900                         0 UDP      LISTENING
127.0.0.1        54806                         0 UDP      LISTENING
192.168.1.18       137                         0 UDP      LISTENING
192.168.1.18       138                         0 UDP      LISTENING
192.168.1.18      1900                         0 UDP      LISTENING
```

## Execute Arbitrary PowerShell As SYSTEM
```
PS C:\Windows\system32> Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "whoami", $NULL

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
PSComputerName   :
```

```
PS C:\Windows\system32> Invoke-WMIMethod -Class Win32_NetConnection -Name RunPs -ArgumentList "Get-Process", $NULL

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
                       134       5     5372       7468    32            8800 audiodg
                       115       6     4664      14344    90     0.31   2272 conhost
                        44       3      560        204    36     0.02   2292 conhost
                       443       7     1724       1336    38             376 csrss
                       396      10     1460       2268    44             440 csrss
                       131       5     2192       1924    32     0.58   6216 dasHost
                      1363      76   226680     291744   733   107.95   1528 devenv
                      1440      83   299828     200472   809   512.25   9488 devenv
                      1302      58   123884      18076   328    64.78   6360 Dropbox
                       247      17   143460      30888   297   613.95    732 dwm
                      3701     120   138920      52632   745   302.63   2476 explorer
                       157       7     1928       2704    82     0.09   4056 FlashUtil_ActiveX
                      1008      61   180364     149852   574 1,464.61   2212 GitHub
                         0       0        0         28     0               0 Idle
                       640      22    11464      19852   167     4.64    152 iexplore
                       552      15    14916       4516   225     7.50    160 iexplore
                       555      16     7056       4212   136     3.06   2732 iexplore
                       701      35    62184      53052   303    15.09   9164 iexplore
                       191       8     6580       1840   103     2.16   1436 IpOverUsbSvc
                      1214      13     5376       5888    40    72.03    544 lsass
                       450      19    53092      12008   281    64.69   6180 Microsoft.Alm.Share...
                       368      18    53924      70952   278     8.38   7172 Microsoft.Alm.Share...
                       158       7     2048        452    31     1.69   2940 msdtc
                       514      43    87432      27192   251            1680 MsMpEng
                       248       6     4060        788    37            2600 NisSrv
                       516      14    36268      43568   214     0.81   7484 powershell
                        94       4      932       1904    35     0.06  10128 RuntimeBroker
                       103       4      768       3652    25     0.00   4900 SearchFilterHost
                       705      39    38756      20740   162    58.95   3084 SearchIndexer
                       301       6     1340       5696    74     0.02   8416 SearchProtocolHost
                       238       5     2724       3040    23             536 services
                      1134      63    19584       3052   217     2.34   1816 SettingSyncHost
                        44       1      192        192     3             264 smss
                       423      14     4040       3568    64     5.73   1268 spoolsv
                        99       5     1060       1060    30     1.45   1548 sqlwriter
                        72       4     1608        852   283     0.09   4376 ssh-agent
                       417       9     3752       4416    41    27.20    600 svchost
                      1507      59    32856      14868   135    27.72    628 svchost
                       900      16    24220      19928    85    41.34    820 svchost
                      2350      30    19508      20820   143   322.63    860 svchost
                       583      21     8572       8560    86    25.80    908 svchost
                       623      12    13668      10708    71   223.61    972 svchost
                      1027      24    10868      10704   132    45.08   1080 svchost
                       482      28    13796      12660    70    39.30   1304 svchost
                       146       6     1792       1836    32     2.47   1564 svchost
                       226      11     9280      13088    90            2236 svchost
                       360      13     3888       4380    58     6.00   2776 svchost
                       885       0       40        568     3               4 System
                       277       8     2000       2956    74    85.47   2228 TabTip
                       234       8     2416       2276    72     0.63   2976 taskhost
                       314      18     5840       6420    98     8.19   2392 taskhostex
                        95       4     1508       4724    23     0.14   8636 taskhostex
                       144       7     9096       9900   100    86.03   2284 TPAutoConnect
                       152       6     1744       1412    52     9.28   1884 TPAutoConnSvc
                        66       3      720        384    37     1.56    752 vmacthlp
                       339      12     6244       6480    82   107.58   1588 vmtoolsd
                       419      17    15884      11036   163   223.20   3828 vmtoolsd
                       108       4     1012        920    25     0.16   9648 VsEtwService
                        76       5      720        192    34     0.09    468 wininit
                       160       5     1080       1328    45     2.22    476 winlogon
                       252      12    35728      31344   159     0.33   9528 WmiPrvSE
                       463       9     2504       1728    62     0.36    372 WUDFHost
                       436       6     1500       1156    37     0.64   1584 WUDFHost
PSComputerName   :
```
