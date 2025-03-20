using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        private UserAddress(){}
        public UserAddress(string receiverName, string receiverPhone, string receiverProvince, string receiverCity,
            string receiverPostalAddress, string receiverPostalCode)
        {
            Guard(receiverName, receiverPhone, receiverProvince, receiverCity, receiverPostalAddress, receiverPostalCode);
            ReceiverName = receiverName;
            ReceiverPhone = receiverPhone;
            ReceiverProvince = receiverProvince;
            ReceiverCity = receiverCity;
            ReceiverPostalAddress = receiverPostalAddress;
            ReceiverPostalCode = receiverPostalCode;
        }
        public long UserId { get; internal set; }
        public string ReceiverName { get; private set; }
        public string ReceiverPhone { get; private set; }
        public string ReceiverProvince { get; private set; }
        public string ReceiverCity { get; private set; }
        public string ReceiverPostalAddress { get; private set; }
        public string ReceiverPostalCode { get; private set; }

        public void Guard(string receiverName, string receiverPhone, string receiverProvince, string receiverCity,
            string receiverPostalAddress, string receiverPostalCode)
        {
            NullOrEmptyDomainDataException.CheckString(receiverName, nameof(receiverName));
            NullOrEmptyDomainDataException.CheckString(receiverPhone, nameof(receiverPhone));
            NullOrEmptyDomainDataException.CheckString(receiverProvince, nameof(receiverProvince));
            NullOrEmptyDomainDataException.CheckString(receiverCity, nameof(receiverCity));
            NullOrEmptyDomainDataException.CheckString(receiverPostalAddress, nameof(receiverPostalAddress));
            NullOrEmptyDomainDataException.CheckString(receiverPostalCode, nameof(receiverPostalCode));

        }
    }
}
