# dyndig
Automated way to search for publicly accessable CCTV/DVR/NVR by particular sub domain in all DYNDNS providers.


# Usage:
./dyndig homecctv

where homecctv is the sub domain part ONLY.

# Sample results:

Trying: https://homecctv.dyndns.org:443
Trying: https://homecctv.zapto.org:443
...
Trying: http://homecctv.hopto.org:80

Found domains:
http://homecctv.selfip.com
http://homecctv.shacknet.us


* The tool tries to establish connections only on https (TCP/443) and http (TCP/80) protocols and ports.
* Many popular dyndns providers and their domains (payed and free) are already included in the configuration file dynDomains.txt. If you required you might   extend with more domains to be scanned.
* The configuration file dvrNvrTitles.txt holds Html <title></title> identification string from different CCTV brands. It is used when positive match found to distinguish between CCTV/DVR/NVR and other types of web servers or just parked domains. You can extend as it best fits your case.

# Requirements:
installed dotnet 5.0 sdk or runtime

https://dotnet.microsoft.com/en-us/download/dotnet/5.0
