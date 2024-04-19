using System.Net.Sockets;
using System.Net;

namespace WebMap.Helpers
{
    public class IPHelper
    {
        public static string GetIPv4()
        {
            // 获取本机名
            string hostName = Dns.GetHostName();

            // 根据主机名获取IP地址列表
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);

            // 获取IPv4地址（如果有的话）
            IPAddress ipv4Address = ipAddresses.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            if (ipv4Address != null)
            {
                return ipv4Address.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
