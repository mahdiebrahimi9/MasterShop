using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Shop.Domain._Shared.Exceptions;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User (){}
        public User(string userName, string email, string phone, string nationalCode, string profileImage, string bankCardNumber)
        {
            Guard(userName, email, phone, nationalCode, bankCardNumber);
            UserName = userName;
            Email = email;
            Phone = phone;
            NationalCode = nationalCode;
            ProfileImage = profileImage;
            BankCardNumber = bankCardNumber;
            Addresses = new List<UserAddress>();
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string NationalCode { get; private set; }
        public string ProfileImage { get; private set; }
        public string BankCardNumber { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public void Edit(string userName, string email, string phone, string nationalCode, string profileImage, string bankCardNumber)
        {
            Guard(userName, email, phone, nationalCode, bankCardNumber);
            UserName = userName;
            Email = email;
            Phone = phone;
            NationalCode = nationalCode;
            ProfileImage = profileImage;
            BankCardNumber = bankCardNumber;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void EditAddress(long addressId, UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
                throw new InvalidDomainDataExcepion("آیدی وارد شده نامعتبر یا وجود ندارد");
            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void RemoveAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (address == null)
                throw new InvalidDomainDataExcepion("آیدی وارد شده نامعتبر یا وجود ندارد");
            Addresses.Remove(address);
        }


        private void Guard(string userName, string email, string phone, string nationalCode, string bankCardNumber)
        {
            NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            NullOrEmptyDomainDataException.CheckString(phone, nameof(phone));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            NullOrEmptyDomainDataException.CheckString(bankCardNumber, nameof(bankCardNumber));

            if (phone.Length < 11 || phone.Length > 11)
                throw new InvalidDomainDataExcepion("شماره وارد شده نامعتبر است");

            if (nationalCode.Length < 10 || nationalCode.Length > 10)
                throw new InvalidDomainDataExcepion("کد ملی وارد شده نامعتبر است");

            if (bankCardNumber.Length < 16 || bankCardNumber.Length > 16)
                throw new InvalidDomainDataExcepion("شماره کارت وارد شده نامعتبر است");
        }

    }
}
