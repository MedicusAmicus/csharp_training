﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInfotmation()
        {
            int contactIndex = 3;

            ContactsData fromTable = app.Contact.GetContactInformationFromTable(contactIndex);
            ContactsData fromEditForm = app.Contact.GetContactInformationFromEditForm(contactIndex);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromEditForm.AllEmail);
        }

       /* [Test]
        public void TestContactInfotmation()
        {
            int contactIndex = 150;

            ContactsData fromTable = app.Contact.GetContactInformationFromTable(contactIndex);
            ContactsData fromEditForm = app.Contact.GetContactInformationFromEditForm(contactIndex);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromEditForm.AllEmail);
        } */
    }
}