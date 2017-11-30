PROJE KONUSU
------------------------------------------------------------------
Bu projede kendi karakterinizi ve classlarınızı yaratarak online olarak insanlarla bir araya gelebildiğiniz bir dövüş simülaötürü hazırlanması amaçlanmıştır ve bu sadece bir demodur.Projenin ilerleyen süreçlerindeki hedefimi ve kullanacağım teknolojileri sizlere
birazdan bahsedeceğim.

1.VİZYON
------------------------------------------------------------------

1.Vuforia kullanılması daha uygun.Vuforia Qualcomm firması tarafından oluşturulan bir yazılım ekibi ve bu ekip yıllardan beri mobil işlemci mimarisi üzerinde çalışıyorlar dolayısıyla Altyapıya hakim olduklarından gerek grafik işlemciye gereksse mobbil işlemciye binecek yükü olabildiğince minimize etmeye çalışan bir component oluşturmaya çalışıyorlar piyasa da çinlilerin yapmış olduğu sistemler dahil çoğunu denedim.
dolayısyla bir genelleme yapabilirim diye düşünüyorum.Vuforia diğerlerine göre daha az sorunsuz ve Free.
Tabiki de bazı diğer rakiplerinin bazı avantajları olabiliyor örneğin bahsetmiş olduğum Çinli firmanın componenti animasyon ve effectlerde düşük GPU kullanımı vaat ediyor ama altını çizerim low-poly objelerde.
Ama Vuforianın daha çok kullanım olmasının sebebi optimize çalışması ve Scaner Object gibi bir mobil uygulaması olması.Basitçe söylemek gerekirse bu uygulama ile her hangi bir objeyi tracklenebilir bir obje haline getirmenize yarıyor.Bir ax sistemi üzerinde cihazı objenin etrafında gezdirerek taratıyorsunuz ve daha sonra size bir out dosyası çıkarıyor ve componente dahil ettikten sonra kütüphane artık tarattığınız objeyi trackleyebiliyor.AR teknolojosi tabiki de tam olarak oturan bir sistem olmadığından zaman zaman tracker da kaymalar olabiliyor.

2.Cross-Platform olarak Unity tercih ettim.Çünkü Vuforia cross platformda Unreal Engine desteği şu an için yok.Diğer bir sebep ise Vuforia yerine ARCore (Google tarafından oluşturulan) ARKit (Apple tarafından oluşturalan) kütüphaneleri tercih  etseydim.Cihaz kısıtlamasına uğrayacaktım.Örnek vermek gerekirse ARView sadece A9 chip setine sahip cihazlarda ve üst serilerinde çalışabiliyor.(iPhone 6S ve yukarısı yani.iPad ler içinse iPad Pro sadece)

3.Olarak şu an için değil ama database bilgilerinin hızlı erişimi ve etkileşimi için cloud query desteği sağlayan Google Firebase API sini kullanmayı düşünüyorum.Bu sayede kullanıcılar kısa bir sürede envanter bilgisi seviye bilgisi swordların dayanıklılık durumu gibi şeylere hızlı erişebilecekler.
Ayrıca REST API hizmeti verdiğinden dolayı real time olarak database eişimi var.Bir den fazla kullanacağı belki de milisaniyelik aralıklarla data yazıp okuyacaklar.

4.Daha sonra kişilerin klan kurup chatleşebileceği oda kurabilecekleri bir plugine ihtiyacağımız olarak başlangıç için belki Photon Networking Plugin tercih edilebilir.Şu an için dünyanın en iyi bağımsız ağ motoru ödülünü aldılar Square Enix ,SEGA gibi oyun firmalarının yanında Unreal Engine,Google , Unity gibi firmalarla da işler yürütmekteler.Plugin de chat odası , oda kurma gibi yapıların hepsi mevcut.

5.Özel günlerde item düşürmek ve kullanıcıları daha çok oyunda tutmaya yönelik eventler düzenlenemebilir. Örn : Ödüllü Arenalar.3D tasarımlar için 3d Max teki ürünler riglenmeli , animasyonları yapılmalı, polygon sayısı turbo smooth teknoloji haline getirildikten sonra Bundle assetlerine Unity tarafında yüklenmeli ve burada bulunan serverlerden bant genişliği yüksek bir sunucuya atılmalı.Uygulama yeni bir karakterin eklenmesi gibi durumlarda bu sunucudan assetleri çekecek.Buna itemler da dahil.Bu sayede düşük dosya boyutlarında yüksek bant genişliklerinde hizmet verilmiş olacak.

6.Bu tarz online ortamlarda argo,taciz gibi olayların olması çok muhtemel bunların önüne geçmek için Bad Word Filter PRO plugini kullamak uygun olacaktır.(23 dil desteği var.) Ceza sistemlerinin derecelerinin belirlemesi gerekecek ve rapor sistemi olacak.Bu raporlama sitemleri karşılaşma sonucunda yayınlanan UI sonuç ekranında kullanıcı profili kısmından gerçekleştirecek.

7.Dövüş sistemlerindeki hamle sistemleri kullanıcıların item class ve skill pointleri üzerinden hesaplanacak bir AI sistemi lazım bunun için Machine Learning teknolojini kullanan AI Designer Pro plugini kullanılması ugyun.Eğer uygulama native bir uygulama olsaydı tercihim iOS platformunda MLCore plugini kullanılabilirdim.

8.Eventlerin haber verilmesi için otomatik mesaj özelliği olan OneSignal API sini kullanmak mantıklı olacaktır.

9.Antremanlar sırasında kazanılan deneyimlere göre Anchiments kazanımları için Google Play Services API si kullanılmalıdır.

2.PRODUCTION
------------------------------------------------------------------

1.Şu an için sunucu tarafında atıcak 3D model bulunmadığından Android tarafında SharedPreferences yapısı ile aynı olan Cross-Platformdaki PlayerPrefs yapısını kullandım.Local bazlı bir cache olarak düşünülebilir.(Localden kastım Uygulama ayarlarından Verileri silinince bu datalar uçuyor.)

2.Vuforianın developer sitesinden component kullanımı için bir adet API Key yarattım.Daah sonra bir Target Manager kütüphanesi yaratarak çekmiş olduğum bir resmi Image Tracker için kütüpheye upload ettim.Daha sonra upload ettiğim kütüpheneyi .unitypackage dosyası olarak indirdikten sonra projeme import ettim.Vuforia configuration panelinden kullanacağım database i seçtim.
Data sonra sahneye bir adet Image Tracker atıp Onunla ilişkilendireceğim objeleri onun cihld ı olarak içine aktardım.Ana camera olan AR Camera sından Extended Tracker seçeneğini seçmek çok onemli Çünkü Extended tracker şu işe yaramaktadir. Bina gibi enine değilde boyuna olan objelerde AR Kamerayı yukarı doğru götürdükçe trackerın ax ından kayarsınız ve 
belli bir açıdan sonra obje ilk titremelere başlar ve daha sonra kaybolur.Extended tracker ise objeyi trackerdan bilgisini bir kere aldıktan sonra cihazdaki anlık erişim birimlerine atar Makinalardaki ROM bellek gibi daha sonra objenin ekseninden çıkıncaya kadar bu bilgiyi hafızalarında tutarlar.

3.Işık gibi açı gibi faktörden çok etkilenen objeler cihazın sürekli fotonların sayısında , şiddetinde hesaplama yapmasına ve makinenin yorulmasına sebep olur yorulan makine ısınır ve elli tutulamaz hale geleceğinden uygulamanın kullanım süresinde düşmeler olabilir.Anlık kullanacağı sayısını fazla tutmak için sahnenin Backing işlemini gerçekleştirdim.

4.Google Firebase API sinde bir Proje yarattıktan sonra proje de bir Realtime Database oluşturdum ve daha sonra google-services.json dosyasını projeye import ettim.Bu API ile haberleşmesini sağlıyor.Daha sonra karakter seçiminden sonra buraya data yazıyorum.Daha sonraki uygulamanın açılışında datayı kontrol ediyor varsa karakter bilgilerini çektirerek direk karakter sahnesine yönlendiriyorum.
