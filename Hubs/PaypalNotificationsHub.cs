//using Microsoft.AspNet.SignalR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SNIAPI.Hubs
//{
//    public class PaypalNotificationsHub : Hub
//    {
//        static IHubContext hubContext;
//        public PaypalNotificationsHub()
//        {
//            //you can send userid, paymentid,tokenid to client
//            hubContext = GlobalHost.ConnectionManager.GetHubContext<PaypalNotificationsHub>();

//        }


//        //[HubMethodName("CustomSendMethod")]
//        public static void PaymentSuccess(string message)
//        {
//            try
//            {

//                hubContext.Clients.All.paymentSuccess(message);

//            }
//            catch
//            {
//            }
//        }
//        public static void PaymentFailure(string message)
//        {
//            try
//            {
//                //you can send userid, paymentid,tokenid to client
//                // var hubContext = GlobalHost.ConnectionManager.GetHubContext<PaypalNotificationsHub>();
//                hubContext.Clients.All.paymentFailure(message);

//            }
//            catch
//            {
//            }
//        }
//    }
//}