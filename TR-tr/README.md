# .NET Yazılımcıları için NEO Blokzinciri Hızlı Başlangıç Rehberi

**TÜRKÇE**

.NET Yazılımcıları için NEO Blokzinciri dökümantasyonu ([url](https://github.com/mwherman2000/neo-windocs/tree/master/windocs))

## Amaç

Bu döküman ile, Neo Blokzinciri teknolojisine yeni başlayan .Net yazılımcılarının NEO geliştirme ortamını mümkün olduğunca hızlı bir şekilde çalıştırabilmesini amaçlamaktadır.

Bu döküman spesifik olarak .NET yazılımcılarını ve mimarlarını hedeflemektedir. 

### Uyarı

Ek olarak, bu dökümanın ilk yazıldığı dönemde (Şubat 2018), [*erken benimseyen*] kafa yapısında olmalısınız (https://en.wikipedia.org/wiki/Technology_adoption_life_cycle). Bunlar ilk günleri. Kullanılacak olan araçların birçoğunun kodunu indirip derleyerek çalıştırmanız gerekecektir (Visual Studio hariç). İlk başta eğlenceli olmayabilir fakat sonunda kesinlikle ödüllendirici olacaktır.

## Hedefler

* Mümkün olduğunca kısa sürede çalışan bir NEO geliştirme ortanının kurulması
* C# ile ilk smart kontraktın oluşturulması, yüklenmesi ve test edilmesi.(HelloWorld örneği kullanılarak)

## Prensipler

* Güvenilir dökümantasyon sağlama: zamanında, doğru, görsel ve tam
* Mümkün olduğunca fazla insanın zamandan tasarrufu
* Münkün olduğunca açık kaynak yazılım kullanmak.

## Sebepler

* Öz ve takip etmesi kolay dökümantasyonun eksikliği

## Bölümler

0. [Gereksinimler ve Tavsiyeler](./00-prerequisites.md)
1. [Download and install Visual Studio 2017 Community Edition integrated development environment (IDE)](./01-installvisualstudio.md)
2. [Download and unpack NEO developer tool projects (source)](./02-downloadneodevtoolsrc.md)
3. [Coffee time: Wait for previous activities to complete](./03-coffeetime-waitforprevactivities.md)
4. [Install NeoContractPlugin Visual Studio extension](./04-installvsneocontractplugin.md)
5. [Build and test NEO developer tool projects (from source)](./05-buildneodevtools.md)
6. [Download, install, and test Docker platform](./06-installdockerplatform.md)
7. [Download and test NEO privatenet Docker container](./07-installneoprivatenetcontainer.md)
8. [Create and compile HelloWorld smart contract sample](./08-createcompilesmartcontract.md)
9. [Deploy and test the HelloWorld smart contract](./09-deploytestsmartcontract.md)
10. [Celebrate](./10-celebrate.md)
11. [Appendix A - Checklist](./11-checklist.md)
12. [Appendix B - Roadmap](./12-roadmap.md)
13. [Appendix C - Reset NEO privatenet Environment: Container, Wallets, and Clients](./13-resetprivatenetenv.md)

## İstatistikler

* 10 temel aktivite, tahmini 130 dökümante edilmiş aktiviteyi kapsayan (yaklaşık)
* 140 ekran görüntüsü (yaklaşık)

    ![Hızlı başlangıç resim koleksiyonu](./images/lighttable.png)

    Figure 0.1. Hızlı Başlangıç Resim Tablosu
* 7 Toplu dosyalar
* 2 JSONayarlar dosyası
* 1 C# kod öreneği

## Referanslar

* [NEOTUTORIAL] NEO Projesi, [NEO smart contract örneği](http://docs.neo.org/en-us/sc/tutorial.html) kaynak [http://docs.neo.org/en-us/sc/tutorial.html](http://docs.neo.org/en-us/sc/tutorial.html)

## Diğer Faydalı Kaynaklar

* [NEOPYTHONTUTORIAL] Nick Fujita, [NEO Smart Contracts Tutorial: helloWorld (Python)](https://steemit.com/neo/@z0yo/neo-smart-contracts-tutorial-helloworld) kaynak [https://steemit.com/neo/@z0yo/neo-smart-contracts-tutorial-helloworld](https://steemit.com/neo/@z0yo/neo-smart-contracts-tutorial-helloworld)

## Geri Bildirim

>Süpersin Mike!

