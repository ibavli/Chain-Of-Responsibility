## Chain Of Responsibility Design Pattern

### Çalışma Mantığı

Uygulama içerisinde tek bir işi yapmak için birden fazla sorumluluğun bulunduğu durumlarda bu işlemleri bir zincir haline getirip sınıflara bölmek şeklinde gerçekleşir. Sınıflar hangi sırayla çalışacaklarını bilmezler ama hangi durumlarda çalışacaklarını bilirler. Sınıf aynı zamanda kendinden sonra hangi sınıfın çalışması gerektiğini de bilir. Zinciri oluşturan bütün sınıflar aynı base'den türerler ve aynı input üzerinde çalışırlar. Ancak bu aynı input üzerinde çalışma durumu bazen esnetilebilir. Yani ilk gelen input için zincirin bir yerinde farklı bir input oluşturulup base'deki bir property'e atanabilir. Sıradakinin çalıştırılması için tetiklendiğinde bütün property'ler sıradaki çalışacak nesneye geçirilebilir. Sistemin hangi sırada çalışacağına ise client karar verir. 

### Ne zaman kullanılır?

İstek ve isteği yapan arasında olabildiğince loosly coupled ilişki kurmak amacıyla yapılır. Yapılması istenen işlem için birden fazla iş yapılması gerekiyorsa bir sorumluluk zinciri kurularak bu sorumluluk yerine getirilir. Desende iş yapan bütün nesneler birbirleriyle iletişim halindedir. Eğer bir iş son derece kompleks ise veya gelen isteğin hangi işlemle cevaplanması gerektiği istemciden gelen input'a göre farklılık gösteriyorsa kullanılır. Yani çok yoğun if-else kullanılması gereken işlemlerde eğer işlemler bir veya birden fazla ortak noktada birleştirilerek bu if-elseler kırılamıyorsa kullanılır. Reflaction'la herhangi bir yerden değer okunarak ilgili sınıfı seçme gibi bir durumda mümkün görünmüyorsa kullanılır.

Hedef kod tekrarını engellemek, sonu gelmeyen if-else bloklarını en aza indirgemek, sistemi soyutlamak  genişletilebilirliği sağlamak.

### Örnek

Örnek olarak bir bankacılık uygulaması gerçekleştirdiğimizi ve kredi modülünde çalıştığımızı düşünelim. Herhangi bir müşteri kredi başvurusunda bulunduğu zaman kredinin verilip verilmeyeceğine karar verirken aşağıdaki maddelere dikkat etmemiz söylendi. Tabi aşağıdaki maddeler sadece taslak içindir. Normalde daha uzun ve karmaşık süreçlerden geçilir.

1. Müşterinin KBB skoruna bak. Skor 1000'den düşükse direkt ret ver. Burada hiç kayıt olmaması durumunu dikkate almıyoruz.

3. Daha önceden kredi kartı var mı, varsa kredi kartına ait borçları ne kadar süreyle geciktirmiş? Bu geciktirme süresi 3 aydan fazla ise direkt ret ver.

5. Müşterinin kefili iyi mi? Değilse ret ver. Kefilinin mutlaka olduğunu varsayıyoruz.

7. Müşterinin aylık geliri istenen krediyi ödemeye yeterli mi? Değilse direkt ret ver.

9. Müşterinin çalıştığı firma kurumsal bir firma mıdır? Değilse direkt ret ver.
