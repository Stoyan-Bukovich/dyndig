#region Using
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System;
using System.Net;
using System.Threading.Tasks;
#endregion

namespace dyndig
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Sub domain part is required. Example: cctv");
                return;
            }
            
            string domainsFile = Path.Combine(Directory.GetCurrentDirectory(), "dynDomains.txt");
            string titlesFile = Path.Combine(Directory.GetCurrentDirectory(), "dvrNvrTitles.txt");
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                domainsFile = domainsFile.Replace('\\', '/');
                titlesFile = titlesFile.Replace('\\', '/');
            }

            List<string> dynDomains = File.ReadAllLines(domainsFile).ToList();
            List<string> titles = File.ReadAllLines(titlesFile).ToList();

            string subDomain = args[0];
            List<string> foundDomains = new List<string>();

            if (dynDomains.Count > 0)
            {
                dynDomains.Sort();
            }

            if (titles.Count > 0)
            {
                titles.Sort();
            }

            if(dynDomains.Count == 0)
            {
                Console.WriteLine("No domains found in dynDomains.txt");
                return;
            }

            List<string> agents = new List<string>();

            agents.Add("Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 [FBAN/FBIOS;FBDV/iPhone11,8;FBMD/iPhone;FBSN/iOS;FBSV/13.3.1;FBSS/2;FBID/phone;FBLC/en_US;FBOP/5;FBCR/]");
            agents.Add("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
            agents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)");
            agents.Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_5) AppleWebKit/605.1.15 (KHTML, like Gecko)");
            agents.Add("Mozilla/5.0 (iPhone; CPU iPhone OS 10_0 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) Version/10.0 YaBrowser/17.4.3.195.10 Mobile/14A346 Safari/E7FBAF");
            agents.Add("Mozilla/5.0 (X11; CrOS x86_64 13597.94.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.186 Safari/537.36");
            agents.Add("Roku/DVP-9.10 (519.10E04111A)");
            agents.Add("Mozilla/5.0 (compatible; Codewisebot/2.0; +https://www.nosite.com/somebot.htm)");
            agents.Add("Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 [FBAN/FBIOS;FBDV/iPhone10,5;FBMD/iPhone;FBSN/iOS;FBSV/13.3.1;FBSS/3;FBID/phone;FBLC/en_US;FBOP/5;FBCR/]");
            agents.Add("Mozilla/5.0 (compatible; bingbot/2.0; +https://www.bing.com/bingbot.htm)");
            agents.Add("Mozilla/5.0 (X11; Ubuntu; Linux i686; rv:24.0) Gecko/20100101 Firefox/24.0");
            agents.Add("Mozilla/5.0 (Linux; Android 5.0) AppleWebKit/537.36 (KHTML, like Gecko) Mobile Safari/537.36 (compatible; Bytespider; https://zhanzhang.toutiao.com/)");
            agents.Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10; rv:33.0) Gecko/20100101 Firefox/33.0");
            agents.Add("Mozilla/5.0 (Linux; Android 5.1.1; KFSUWI) AppleWebKit/537.36 (KHTML, like Gecko) Silk/81.1.233 like Chrome/81.0.4044.117 Safari/537.36");
            agents.Add("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36");
            agents.Add("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)");
            agents.Add("Mozilla/4.0 (compatible; MSIE 9.0; Windows NT 6.1)");
            agents.Add("Mozilla/5.0 (Windows NT 10.0; Trident/7.0; rv:11.0) like Gecko");
            agents.Add("Mozilla/5.0 (Macintosh; Intel Mac OS X 11_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 OPR/77.0.4054.277");
            agents.Add("Googlebot-Image/1.0");
            agents.Add("Mozilla/5.0 (Linux; U; Android 2.3; en-us) AppleWebKit/999+ (KHTML, like Gecko) Safari/999.9");
            agents.Add("Mozilla/5.0 (Linux; U; Android 2.3.4; fr-fr; HTC Desire Build/GRJ22) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1");
            agents.Add("Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; Media Center PC 6.0; InfoPath.3; MS-RTC LM 8; Zune 4.7)");
            agents.Add("Mozilla/4.0 (compatible; MSIE 4.0; Windows 95; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            agents.Add("Mozilla/2.0 (compatible; MSIE 3.0; Windows 3.1)");
            agents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27");
            agents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_6; zh-cn) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27");
            agents.Add("Opera/9.80 (X11; Linux i686; Ubuntu/14.10) Presto/2.12.388 Version/12.16.2");
            agents.Add("Opera/9.60 (Windows NT 6.0; U; bg) Presto/2.1.1");
            agents.Add("Opera/9.80 (Windows NT 5.1; U; cs) Presto/2.2.15 Version/10.10");
            agents.Add("Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25");
            agents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X 10_5_8; ja-jp) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27");
            agents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_6; en-us) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27");
            agents.Add("Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.96 Mobile Safari/537.36 (compatible; Googlebot/2.1; +https://www.google.com/bot.html)");
            agents.Add("Mozilla/5.0 (compatible; Yahoo! Slurp; https://help.yahoo.com/help/us/ysearch/slurp)");
            agents.Add("Mozilla/5.0 (compatible; SemrushBot/7~bl; +https://www.semrush.com/bot.html)");
            agents.Add("Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30)");

            Random ran = new Random();
            int index = ran.Next(0, agents.Count-1);
            string Agent = agents[index].ToString();

            foreach(string domain in dynDomains)
            {
                try
                {
                    Console.WriteLine("Trying: https://" + subDomain.Trim() + "." + domain.Trim() + ":443");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + subDomain.Trim() + "." + domain.Trim());
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Timeout = 2000;
                    request.Proxy = null;
                    request.UserAgent = Agent;
                    request.Accept = "*/*";
                    request.Method = "GET";
                    request.Headers.Clear();
                    request.ContentType = "text/html";

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
                    Stream data = response.GetResponseStream();
                    StreamReader sr = new StreamReader(data);

                    string html = sr.ReadToEnd();
                    string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";

                    System.Text.RegularExpressions.Regex ex = new System.Text.RegularExpressions.Regex(regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    String title = ex.Match(html).Value.Trim();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Response: {0} - {1}", response.StatusDescription, subDomain.Trim() + "." + domain.Trim());
                        Console.WriteLine("Title: " + title);
                        Console.ResetColor();
                        
                        foreach (string dvrNvrTitle in titles)
                        {
                            if (dvrNvrTitle.Contains(title.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                foundDomains.Add("https://" + subDomain.Trim() + "." + domain.Trim());
                                break;
                            }
                        }
                    }

                    response.Close();
                }
                catch {}
            }

            foreach(string domain in dynDomains)
            {
                try
                {
                    // Console.Clear();
                    Console.WriteLine("Trying: http://" + subDomain.Trim() + "." + domain.Trim() + ":80");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + subDomain.Trim() + "." + domain.Trim());
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.Timeout = 2000;
                    request.Proxy = null;
                    request.UserAgent = Agent;
                    request.Accept = "*/*";
                    request.Method = "GET";
                    request.Headers.Clear();
                    request.ContentType = "text/html";

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
                    Stream data = response.GetResponseStream();
                    StreamReader sr = new StreamReader(data);

                    string html = sr.ReadToEnd();
                    string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";

                    System.Text.RegularExpressions.Regex ex = new System.Text.RegularExpressions.Regex(regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    String title = ex.Match(html).Value.Trim();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Response: {0} - {1}", response.StatusDescription, subDomain.Trim() + "." + domain.Trim());
                        Console.WriteLine("Title: " + title);
                        Console.ResetColor();
                                                
                        foreach (string dvrNvrTitle in titles)
                        {
                            if (dvrNvrTitle.Contains(title.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                foundDomains.Add("http://" + subDomain.Trim() + "." + domain.Trim());
                                break;
                            }
                        }
                    }

                    response.Close();
                }
                catch {}
            }

            if(foundDomains.Count == 0)
            {
                Console.WriteLine("No domains found");
            }
            else
            {
                Console.WriteLine("\r\nFound domains: ");

                foreach(string domain in foundDomains)
                {
                    Console.WriteLine(domain);
                }
            }
        }
    }
}