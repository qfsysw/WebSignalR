using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace WebSignalR
{

        public class ChatHub : Hub
        {

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task SendMessage(Msg entity)
        {
            if (Clients != null)
                await Clients.All.SendAsync("ReceiveMessage", entity.user, entity.message);// $"{entity.user} 发送消息：{entity.message}"); //entity.user, entity.message);/
        }

 
        /// <summary>
        /// 发送消息2
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage2(string user, string message)
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }

        /// <summary>
        /// 重写集线器连接事件	
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId}已连接");
            return base.OnConnectedAsync();
        }
      


        /// <summary>
        /// 重写集线器关闭事件
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("关闭事件");
            return base.OnDisconnectedAsync(exception);
        }
    }

    /// <summary>
    /// 消息类
    /// </summary>
    public class Msg
    {
        public string? user { get; set; }
        public string? message { get; set; }
    }


}
