using Banka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankaTestleri
{
    [TestClass]
    public class HesapTest
    {
        [TestMethod]
        public void ParaCekme_DogruMiktarla_BakiyeGunceller()
        {
            //arrange: test ön hazýrlýk
            decimal baslangicBakiye = 76.40m;
            decimal cekilecekTutar = 19.63m;
            decimal beklenen = 56.77m;

            Hesap hesap = new Hesap("Ali Yýlmaz", baslangicBakiye);

            //Act: Eylem
            hesap.ParaCek(cekilecekTutar);

            //Assert: kontrol
            decimal gercek = hesap.Bakiye;
            Assert.AreEqual(beklenen, gercek,"Para doðru çekilemedi.");
        }

        [TestMethod]
        public void ParaCek_BakiyeSifirAltinaDuserse_ArgumentOutOfRangeHatasiFirlatmali()
        {
            //test ön hazýrlýk
            decimal baslangicBakiye = 100m;
            decimal cekilecekTutar = 110m;
            Hesap hesap = new Hesap("Ali Yýlmaz", baslangicBakiye);

            //act & assert: eylem ve iddia
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hesap.ParaCek(cekilecekTutar));
        }
    }
}
