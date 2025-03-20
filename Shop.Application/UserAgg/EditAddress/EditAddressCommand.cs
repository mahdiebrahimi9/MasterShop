using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.UserAgg.EditAddress
{
    public class EditAddressCommand : IRequest
    {
        public EditAddressCommand(long userId, string receiverName, string receiverPhone, string receiverProvince, string receiverCity, string receiverPostalAddress, string receiverPostalCode, long addressId)
        {
            UserId = userId;
            ReceiverName = receiverName;
            ReceiverPhone = receiverPhone;
            ReceiverProvince = receiverProvince;
            ReceiverCity = receiverCity;
            ReceiverPostalAddress = receiverPostalAddress;
            ReceiverPostalCode = receiverPostalCode;
            AddressId = addressId;
        }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverProvince { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverPostalAddress { get; set; }
        public string ReceiverPostalCode { get; set; }
    }
}
