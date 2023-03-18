using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly TKDecorContext _db;

        public DbInitializer(TKDecorContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            if (_db.Categories.Any())
            {
                return;
            }

            //add category
            List<Category> categories = new()
            {
                new Category() {Description = "Bàn"},
                new Category() {Description = "Ghế"},
                new Category() {Description = "Giường"},
                new Category() {Description = "Tủ"},
                new Category() {Description = "Kệ"},
                new Category() {Description = "Đèn"},
                new Category() {Description = "Rèm"},
                new Category() {Description = "Thảm"},
                new Category() {Description = "Gương"},
                new Category() {Description = "Bình hoa"},
                new Category() {Description = "Giấy dán tường"},
                new Category() {Description = "Bình rượu"},
                new Category() {Description = "Tượng"},
                new Category() {Description = "Hồ cá"},
                new Category() {Description = "Đồng hồ"},
                new Category() {Description = "Ly"},
                new Category() {Description = "Đĩa"},
                new Category() {Description = "Quạt"}
            };
            _db.Categories.AddRange(categories);
            _db.SaveChanges();

            //add role
            _db.Roles.Add(new Role { Description = RoleContent.Admin });
            _db.SaveChanges();
            _db.Roles.Add(new Role { Description = RoleContent.Customer });
            _db.SaveChanges();

            //add user
            _db.Users.Add(new User {
                RoleId = 1,
                Email = "Admin@gmail.com",
                Password = HasPassword.HashPassword("Admin@gmail.com"),
                EmailConfirmed = true
            });
            _db.SaveChanges();
            List<User> users = new List<User>()
            {
                new User{ Address = "Hà Nội" },
                new User{ Address = "Hồ Chí Minh" },
                new User{ Address = "Đà Nẵng" },
                new User{ Address = "Huế" },
                new User{ Address = "Cần Thơ" },
                new User{ Address = "Vĩnh Long" },
                new User{ Address = "Phú Yên" },
                new User{ Address = "Đồng Tháp" },
                new User{ Address = "An Giang" },
                new User{ Address = "Bà Rịa - Vũng Tàu" },
                new User{ Address = "Bắc Giang" },
                new User{ Address = "Bắc Kạn" },
                new User{ Address = "Bạc Liêu" },
                new User{ Address = "Bắc Ninh" },
                new User{ Address = "Bến Tre" },
                new User{ Address = "Bình Định" },
                new User{ Address = "Bình Dương" },
                new User{ Address = "Bình Phước" },
                new User{ Address = "Bình Thuận" },
                new User{ Address = "Cà Mau" },
                new User{ Address = "Cao Bằng" },
                new User{ Address = "Đắk Lắk" },
                new User{ Address = "Đắk Nông" },
                new User{ Address = "Điện Biên" },
                new User{ Address = "Đồng Nai" },
                new User{ Address = "Gia Lai" },
                new User{ Address = "Hà Giang" },
                new User{ Address = "Hà Nam" },
                new User{ Address = "Hà Tĩnh" },
                new User{ Address = "Hải Dương" },
                new User{ Address = "Hải Phòng" },
                new User{ Address = "Hậu Giang" },
                new User{ Address = "Hòa Bình" },
                new User{ Address = "Hưng Yên" },
                new User{ Address = "Khánh Hòa" },
                new User{ Address = "Kiên Giang" },
                new User{ Address = "Kon Tum" },
                new User{ Address = "Lai Châu" },
                new User{ Address = "Lâm Đồng" },
                new User{ Address = "Lạng Sơn" },
                new User{ Address = "Lào Cai" },
                new User{ Address = "Long An" },
                new User{ Address = "Nam Định" },
                new User{ Address = "Nghệ An" },
                new User{ Address = "Ninh Bình" },
                new User{ Address = "Ninh Thuận" },
                new User{ Address = "Phú Thọ" },
                new User{ Address = "Quảng Bình" },
                new User{ Address = "Quảng Nam" },
                new User{ Address = "Quảng Ngãi" },
                new User{ Address = "Quảng Ninh" },
                new User{ Address = "Quảng Trị" },
                new User{ Address = "Sóc Trăng" },
                new User{ Address = "Sơn La" },
                new User{ Address = "Tây Ninh" },
                new User{ Address = "Thái Bình" },
                new User{ Address = "Thái Nguyên" },
                new User{ Address = "Thanh Hóa" },
                new User{ Address = "Thừa Thiên Huế" },
                new User{ Address = "Tiền Giang" },
                new User{ Address = "Trà Vinh" },
                new User{ Address = "Tuyên Quang" },
                new User{ Address = "Vĩnh Phúc" },
                new User{ Address = "Yên Bái" }
            };

            int i = 0;
            foreach (var item in users)
            {
                i++;
                item.RoleId = 2;
                item.Email = $"Customer{i}@gmail.com";
                item.Password = HasPassword.HashPassword($"Customer{i}@gmail.com");
                item.FullName = $"Customer {i}";
                item.Phone = $"0788223{i}{i * 2}";
                item.EmailConfirmed = true;
            }
            _db.Users.AddRange(users);
            _db.SaveChanges();

            //add products
            Random random = new Random();
            DateTime start = new(2020, 1, 1);
            int range = (DateTime.Today - start).Days;

            List<Product> products = new()
            {
                new Product { Description="Chiều cao bàn ăn tiêu chuẩn thường nhất quán (trung từ 71 – 76cm), Nhưng quý vị cần cân nhắc khoảng cách khi chúng ta kéo ghế ra ngồi ăn cơm. Đủ không gian cho mọi người ngồi vừa và bắt chéo chân, không quá cao gây cảm giác vướng, khó chịu. Nói chung, khoảng cách từ ghế và bàn ăn cách khoảng 30cm.",Thumbnail="/images/products/ban-tron.jpg",  Title = "Bàn tròn" },
                new Product { Description="Kích thước bàn: Dài = 120cm ; Rộng = 60cm ; Cao = 75cm.Mặt bàn: Được làm bằng gỗ MDF cao cấp có độ dày 17 li. Mặt bàn phue melamine chống thấm, chống xước và có độ bền đẹp cao.Khung bàn: Được làm bằng sắt có kết cấu chắc chắn. Bên ngoài được sơn phủ bởi lớp sơn tĩnh điện có thẩm mỹ cực cao. Sơn tĩnh điện chống xước, chống han rỉ. Lớp sơn bảo vệ cho khung sắt có độ bền len tới 10 năm.Bàn được đóng hộp carton dày 8 lii chắc chắn và chuyên nghiệp",Thumbnail="/images/products/ban-chu-z.jpg", Title = "Bàn chữ Z" },
                new Product { Description="Kích thước: Dài x Rộng x Cao (120 x 60 x 48/52)cm, Màu sắc: Đỏ, vàng, xanh lá và xanh dương , Chất liệu: Nhựa PP + sắt sơn tĩnh điện chắc chắn, bền đẹp, không phai màu…",Thumbnail="/images/products/ban-nhua.jpg", Title = "Bàn Nhựa" },
                new Product { Description="Kích thước: Cao 55 cm; mặt ghế tròn đường kính 32 cm . Đặc điểm:  + Mặt ghế được tạo hình bằng máy ép thuỷ lực 250 tấn, đường nét sắc sảo, chắc chắn. Có sần chống trơn trượt. Trên mặt dập logo “Inox Nam Việt”. Chân ghế tròn phi 19, sử dụng máy uốn chuyên dụng, nhanh, đẹp, chính xác.Dưới mặt ghế có đệm cao su giúp ghế không bị lõm sau một thời gian sử dụng, không phát ra tiếng kêu khi ngồi như các loại ghế thông thường trên thị trường.Các mối hàn được thực hiện bằng công nghệ hàn TIG có khí Ar bảo vệ chống oxi hóa.",Thumbnail="/images/products/ghe-tron.jpg", Title = "Ghế tròn" },
                new Product { Description="Ghế gỗ tròn gồm có 3 chân nên tạo sự chắc chắn và mạnh mẽ trong từng góc nhìn.Thiết kế cao phù hợp ngồi tại quầy bar, rượu.Ghế 3 chân gỗ có màu nâu gỗ đi cùng với vàng/đỏ ở các chi tiết mặt ghế và chân ghế giúp nổi bật. Thiết kế đơn giản, gọn nhẹ dễ di chuyển và xếp gọn. Mặt ghế ngồi hình tròn bằng nhựa cứng được uốn cong bo xuống tạo thiết kế mềm mại.",Thumbnail="/images/products/ghe-3-chan.jpg",  Title = "Ghế 3 chân" },
                new Product { Description="Khung gỗ sử dụng thường xuyên nhất đối với các bộ ghế sofa. Cấu tạo khung ghế sofa khá đơn giản. Chúng bao gồm các thanh gỗ được kết nối với nhau. Tạo thành hệ thống trợ lực nâng đỡ cho nhau. Đảm bảo lực được phân tán đều lên các thanh chịu lực. Tránh hiện tượng bị gãy khung khi sử dụng. Với ghế sofa sử dụng khung gỗ thông thường có thể chịu được từ 5-7 người sử dụng cùng lúc hoặc có thể hơn. Tương ứng với trọng lượng người sử dụng từ 350-400kg.",Thumbnail="/images/products/ghe-sofa.jpg", Title = "Ghế sofa" },
                new Product { Description="Là siêu phẫm mang hơi hướng Tây hóa vào thị trường Việt Nam từ nhiều năm nay,hình dáng bên ngoài đẹp, bắt mắt. Nó có nhiều mẫu mã ấn tượng, giường tròn có kết cấu tròn đều,có vài mẫu có kiểu giật nút bắt mắt, nệm bên trong cao 10 phân hay 20 phân tùy theo sở thích gia chủ.",Thumbnail="/images/products/giuong-tron.jpg", Title = "Giường tròn" },
                new Product { Description="Giường đôi là loại giường được sử dụng phổ biến nhất, dành cho nhiều đối tượng khác nhau, có chiều rộng khoảng từ 1,4m đến 2,2m và chiều dài khoảng 2m.Kích thước phổ biến của loại giường này là 1,8m2m được gọi là King size. Ngoài ra còn có giường đôi có kích thước 1,6m2m (Queen size) và 2m2m hay 2,2m2m (Super king size).",Thumbnail="/images/products/giuong-doi.jpg", Title = "Giường Đôi" },
                new Product { Description="Sử dụng gỗ tự nhiên để thiết kế giường ngủ sẽ đem đến cho bạn sự chắc chắn, an toàn, tuổi thọ của giường cao. Ngoài ra, giường ngủ bằng gỗ tự nhiên có thể chạm trổ, điêu khắc nhiều kiểu kết hợp cùng các vân gỗ tạo nên sự sang trọng cho căn phòng. Tuy nhiên, sử dụng gỗ tự nhiên thì chi phí cao về vật liệu lẫn gia công.",Thumbnail="/images/products/giuong-go.jpg", Title = "Giường Gỗ" },
                new Product { Description="Phong cách: đơn giản và hiện đại. Loại vật liệu: ABS. Please confirm that you can wait. Đây là sản phẩm đặt trước và mất khoảng 7-10 ngày để nhận hàng. Cảm ơn bạn. Shop chúng tôi bảo hành sản phẩm trong vòng 3 ngày kể từ ngày khách hàng nhận được sản phẩm. Shop sẽ đổi sản phẩm hoặc",Thumbnail="/images/products/tu-tron.jpg", Title = "Tủ tròn" },
                new Product { Description="Kích thước: (Rộng 38cm x Sâu 45.5cm x Cao 81cm),Màu sắc: Nhiều màu,Thiết kế: 3 tầng, 3 ngăn kéo,",Thumbnail="/images/products/tu-3-ngan.jpg", Title = "Tủ 3 Ngăn" },
                new Product { Description="Tủ tài liệu sắt đã và đang trở thành nội thất không thể thiếu cho mọi không gian sinh hoạt, làm việc. Tủ sắt mang rất nhiều đặc điểm vượt trội dùng để lưu trữ tài liệu, thông tin của công ty và văn phòng. Hiện nay, có rất nhiều mẫu tủ sắt đựng tài liệu có mặt trên thị trường, mỗi thiết kế lại phù hợp với những không gian, nhiệm vụ khác nhau, làm thế nào để lựa chọn được mẫu tủ phù hợp với văn phòng, khiến nó có thể phát huy được ưu điểm vượt trội",Thumbnail="/images/products/tu-tai-lieu.jpg", Title = "Tủ Tài Liệu" },
                new Product { Description="kệ kho hàng với các tải trọng khác nhau, giúp cho doanh nghiệp, khách hàng có thể lựa chọn thoải mái hơn: kệ trung tải, kệ selective, kệ drive in, kệ double deep, kệ pallet, kệ pallet trượt, kệ sàn…",Thumbnail="/images/products/ke-kho-hang.jpg", Title = "Kệ Kho Hàng" },
                new Product { Description="Kết cấu kệ treo tường không giá đỡ (giấu chân âm kệ) rất chắn chắn và đẹp (không lộ phụ kiện ra ngoài).Gỗ công nghiệp HMR hay còn gọi là MDF lõi xanh chống ẩm. Bề mặt được phủ melamine có khả năng chống trầy xước, chịu nhiệt tốt và dễ dàng vệ sinh. Dễ dàng lắp ráp: Sản phẩm được gia công bằng CNC tự động, các vị trí liên kết đều có độ chuẩn xác nên rất dễ dàng trong quá trình lắp ráp sản phẩm.",Thumbnail="/images/products/ke-go.jpg", Title = "Kệ Gỗ" },
                new Product { Description="Còn được gọi ụ tròn khuyến mãi – một sản phẩm được phân phối và sản xuất với mục đích trưng bày sản phẩm ở các cửa hàng, siêu thị. Tên gọi của kệ cũng bắt nguồn từ hình dáng đặc trưng với những mâm tròn xếp thành tầng.Cấu tạo của kệ siêu thị tròn cũng khá đơn giản, bao gồm mâm đáy, các mâm tầng hình tròn, cột trụ, và các phụ kiện đi kèm. Phần rào chắn bên ngoài sẽ giúp cho sản phẩm trưng bày không bị rơi, đồng thời tăng tính thẩm mỹ cho gian hàng.",Thumbnail="/images/products/ke-tron.jpg", Title = "Kệ tròn" },

                new Product { Description="Bàn trà Hoa lê sản xuất đi theo phong cách hiện đại, đa dạng về mẫu mã dễ dàng phối hợp với bất kỳ mẫu ghế sofa hiện đại nào.Chất liệu chúng tôi sử dụng chủ yếu làm bàn trà.",Thumbnail="/images/products/ban-tra.jpg", Title = "Bàn trà" },
                new Product { Description="Bàn ăn cho gia đình người Việt có rất nhiều kiểu hình dáng khác nhau, và tùy theo không gian sống mà chúng ta có những lựa chọn kích thước bàn ăn tiêu chuẩn phù hợp nhất.",Thumbnail="/images/products/ban-an.jpg", Title = "Bàn ăn" },
                new Product { Description="Ghế ăn giá rẻ được làm từ chất liệu gỗ tự nhiên, gỗ công nghiệp đang được khách hàng ưu tiên lựa chọn. Mỗi một loại gỗ lại có đặc điểm riêng thu hút khách hàng.",Thumbnail="/images/products/ghe-an.jpg", Title = "Ghế ăn" },
                new Product { Description="Tủ quần áo âm tường không chỉ tiết kiệm diện tích mà còn có tính thẩm mỹ cao đem lại một phòng ngủ hiện đại, tinh tế nhưng không kém phần sang trọng.",Thumbnail="/images/products/tu-quan-ao.jpg", Title = "Tủ quần áo" },
                new Product { Description="Bàn làm việc tại nhà là một đồ dùng nội thất cá nhân, là nơi bạn có thể làm việc với máy tính, đọc sách, làm báo cáo… ",Thumbnail="/images/products/ban-lam-viec.jpg", Title = "Bàn làm việc" },
                new Product { Description="Đôi khi là những chiếc ghế chân quỳ sử dụng trong phòng họp. Ghế làm việc hiện đại thường sử dụng một chân chịu lực duy nhất bên dưới ghế.\r\nGhế văn phòng Hòa Phát là dòng sản phẩm ghế làm việc được thiết kế phù hợp với nhu cầu sử dụng của mọi người, chính vì thế ai cũng có thể sử dụng được, ngay cả khi bạn ngồi thư giản, ngồi làm việc đều có thể sử dụng được.",Thumbnail="/images/products/ghe-van-phong.jpg", Title = "Ghế văn phòng" },
                new Product { Description="Kệ Sách Gỗ Trang Trí Để Sàn Cao Cấp với thiết kế mới lạ và vô cùng độc đáo mang vẻ đẹp hiện đại với nhiều tính năng vượt trội đáp ứng đầy đủ nhu cầu khách hàng. Sản phẩm được sử dụng trong trang trí phòng khách, phòng làm việc tại nhà và cả các văn phòng.",Thumbnail="/images/products/ke-sach.jpg", Title = "Kệ sách" },
                new Product { Description="Kệ trang trí đang là một xu hướng được yêu thích, thay thế cho những chiếc tủ cồng kềnh nhằm tiết kiệm diện tích không gian nhằm tối đa hóa nhu cầu sử dụng.",Thumbnail="/images/products/ke-trang-tri.jpg", Title = "Kệ trang trí" },
                new Product { Description="Bàn trang điểm hay còn với tên cái dân dã là bàn phấn. Đây không chỉ là món nội thất tạo điểm nhấn thu hút giúp không gian trở nên sang trọng và tinh tế hơn. Mà bàn trang điểm còn mang lại cho các nàng một góc làm đẹp hoàn hảo.",Thumbnail="/images/products/ban-phan.jpg", Title = "Bàn phấn" },
                new Product { Description="Ghế gỗ mang hình thức đẹp, trang nhã rất thích hợp dùng để trang trí.Sản phẩm có độ bền và chắc chắn, có tuổi thọ cao.Thể hiện được gu thẩm mỹ và phong cách cá nhân của người sử dụng.Rất tiện lợi vì độ gọn nhẹ và dễ dàng sử dụng ở bất kì đâu",Thumbnail="/images/products/ghe-dau.jpg", Title = "Ghế đẩu" },
                new Product { Description="bàn Cafe chân sắt với mặt bàn tròn hoặc vuông kích thước từ 60-80cm đa dạng chất liệu mặt bàn như mặt bàn gỗ tre, gỗ me tây nguyên tấm, gỗ cao su,",Thumbnail="/images/products/ban-cafe.jpg", Title = "Bàn cafe" },
                new Product { Description="Đèn bàn RD-RL-60 sử dụng chip LED SunLike ánh sáng tương tự ánh sáng mặt trời kết hợp chậu cây tô điểm cho căn phòng, tăng hiệu quả học tập, làm việc.",Thumbnail="/images/products/den-ban.jpg", Title = "Đèn bàn" },
                new Product { Description="Đèn trần phòng khách hiện đại 3 màu độc đáo kết hợp công nghệ Led tiết kiêm điện năng và ý tưởng mới lạ của nghệ nhân đèn đã tạo nên tác phẩm xuất sắc.\r\n",Thumbnail="/images/products/den-tran.jpg", Title = "đèn trần" },
                new Product { Description="Rèm cửa phòng khách là 1 loại phụ kiện quan trọng để hoàn thiện đồ nội thất trong phòng cũng như tạo ra một loại tâm trạng tích cực và không khí vui tươi.\r\n",Thumbnail="/images/products/rem-cua.jpg", Title = "rèm cửa" },
                new Product { Description="Thảm rối đa hoạ tiết đặc biệt chỉ có kích thước 40x60(cm) nên thảm thích hợp đặt trước cửa nhà riêng, căn hộ, văn phòng, phòng riêng, nhà vệ sinh, phòng tắm,",Thumbnail="/images/products/tham-trai-san.jpg", Title = "thảm trải sàn" },

                new Product { Description="Mang kiểu dáng và hơi thở của nội thất châu Âu, gương tròn treo tường hoa hướng dương cổ điển được thiết kế tỉ mỉ, tinh tế đến từng chi tiết.",Thumbnail="/images/products/guong-tron.jpg", Title = "gương tròn" },
                new Product { Description="Một nhà thiết kế lừng danh đã từng nói: “Không có đường biên giới hạn cho sáng tạo nghệ thuật”. Có lẽ bởi tinh thần ấy, mà trong ngành thiết kế nội thất, những mẫu mã sản phẩm luôn có sự vận động, thay đổi không ngừng. Đã qua rồi cách tư duy rập khuôn theo chức năng như gương chỉ để soi, bình chỉ để cắm hoa,… Giờ đây, bất cứ vật phẩm gì trong không gian nội thất cũng được truyền tải nét đẹp thẩm mỹ từ sáng tạo nghệ thuật. Trong bài viết này, chúng tôi muốn giới thiệu đến bạn đọc một sản phẩm như vậy. Đó chính là thiết kế gương nghệ thuật hình tròn – hội tụ tinh hoa của sáng tạo.",Thumbnail="/images/products/guong-tron-nghe-thuat.jpg", Title = "gương tròn nghệ thuật" },
                new Product { Description="Mang kiểu dáng và hơi thở của nội thất châu Âu, gương tròn treo tường hoa hướng dương cổ điển được thiết kế tỉ mỉ, tinh tế đến từng chi tiết.",Thumbnail="/images/products/guong-treo-tuong.jpg", Title = "gương treo tường" },
                new Product { Description="Bình hoa gốm Bát Tràng cao cấp cắm hoa vẽ tay thủ công trên nền men mộc vintage trang trí phòng khách đẹp Mộc Gốm MG78",Thumbnail="/images/products/binh-hoa-ve-tay.jpg", Title = "Bình hoa vẽ tay" },
                new Product { Description="Bình thủy tinh họa tiết trái cây với chất liệu chính là thủy tinh borosilicate và nhựa ABS an toàn cho sức khỏe. Chiều cao 20cm. Đường kính 6,5cm.",Thumbnail="/images/products/binh-thuy-tinh.jpg", Title = "Bình hoa thủy tinh" },
                new Product { Description="Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu",Thumbnail="/images/products/giay-dan-tuong-retro.jpg", Title = "Giấy dán tường retro" },
                new Product { Description="Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu",Thumbnail="/images/products/giay-dan-tuong-gia-gach.jpg", Title = "Giấy dán tường giả gạch" },
                new Product { Description="Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu",Thumbnail="/images/products/giay-dan-tuong-den-nham.jpg", Title = "Giấy dán tường đen nhám" },
                new Product { Description="Màu sắc trang trí họa tiết trên bình ngâm rượu thường đơn giản, không lòe loẹt, nhưng vô cùng bắt mắt và tinh sảo. Cấu tạo bên trong và bên ngoài của bình ngâm",Thumbnail="/images/products/binh-ruou-ngam-trang-tri.jpg", Title = "Bình rượu ngâm trang trí" },
                new Product { Description="Rượu vang là một thức uống có cồn làm từ nho lên men . Nấm men tiêu thụ đường trong nho và chuyển đổi nó thành ethanol , carbon dioxide và nhiệt. Các giống nho và chủng nấm men khác nhau tạo ra các kiểu rượu khác nhau. Những biến thể này là kết quả của sự tương tác phức tạp giữa sự phát triển sinh hóa của nho, các phản ứng liên quan đến quá trình lên men, terroir và quá trình sản xuất. Nhiều quốc gia ban hành tên gọi pháp lý nhằm xác định phong cách và chất lượng của rượu vang",Thumbnail="/images/products/binh-ruou-vang.jpg", Title = "Bình rượu vang" },
                new Product { Description="Nuôi cá cảnh mini với số lượng vừa đủ. Hồ cá mini nhỏ nên bạn chỉ nuôi vài con, tránh tình trạng cá chết do thiếu oxy và không đủ không gian bơi lội.",Thumbnail="/images/products/ho-ca-mini.jpg", Title = "Hồ cá mini" },
                new Product { Description=" Bể cá thủy sinh luôn mang đến cho mỗi người chúng ta một cảm giác rất đặc biệt về tâm lý và thị giác. Một không gian xanh, tươi mới",Thumbnail="/images/products/ho-ca-thuy-sinh.jpg", Title = "Hồ cá thủy sinh" },
                new Product { Description=" Không gian xanh ngoài trời của gia đình bạn sẽ tăng thêm vẻ đẹp khi có thêm sự xuất hiện của bể cá xi măng. Thiết kế này sẽ giúp khu vườn trông ...",Thumbnail="/images/products/ho-ca-xi-mang.jpg", Title = "Hồ cá xi măng" },
                new Product { Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="/images/products/dong-ho-trang-tri-giot-nuoc.jpg", Title = "Đồng hồ trang trí giọt nước" },
                new Product { Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="/images/products/dong-ho-treo-tuong-decor-vuon-chim.jpg", Title = "Đồng hồ treo tường decor vườn chim" },
                new Product { Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="/images/products/dong-ho-treo-tuong-3d.jpg", Title = "Đồng hồ treo tường 3d" },
                new Product { Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="/images/products/dong-ho-treo-tuong-con-thuyen.jpg", Title = "Đồng hồ treo tường con thuyền" },
                new Product { Description="Chiếc Ly Đơn Giản/Tinh Tế,",Thumbnail="/images/products/ly-trang-tri.jpg", Title = "Ly trang trí" },
                new Product { Description="Chiếc Ly Đơn Giản/Tinh Tế,",Thumbnail="/images/products/ly-su-trang-tri.jpg", Title = "Ly sứ trang trí" },
                new Product { Description="Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc",Thumbnail="/images/products/dia-trang-tri.jpg", Title = "Đĩa trang trí" },
                new Product { Description="Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc",Thumbnail="/images/products/dia-chim-cong.jpg", Title = "Đĩa trang trí hình chim công" },
                new Product { Description="Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc",Thumbnail="/images/products/dia-su-trang-tri-gia-co-ve-hoa-cuc.jpg", Title = "Đĩa trang trí vẽ hoa cúc" },
                new Product { Description=" Gây ấn tượng với họa tiết được cách điệu từ nhân vật mang điệu múa dân tộc Chăm, chiếc quạt được trang trí mang đậm tính dân tộc",Thumbnail="/images/products/quat-vai-treo-tuong.jpg", Title = "Quạt vải treo tường" },
                new Product { Description=" Gây ấn tượng với họa tiết được cách điệu từ nhân vật mang điệu múa dân tộc Chăm, chiếc quạt được trang trí mang đậm tính dân tộc",Thumbnail="/images/products/quat-nan-treo-tuong.jpg", Title = "Quạt nan treo tường"},
            };
            var categoryListDb = _db.Categories.ToList();

            foreach (var item in products)
            {
                //add CategoryId for product when title contains category description
                foreach (var cate in categoryListDb)
                {
                    if (item.Title.ToLower().Trim().Contains(cate.Description.ToLower().Trim()))
                    {
                        item.CategoryId = cate.Id;
                        break;
                    }
                }
                //item.UserId = 1;
                item.RecentPrice = new Random().Next(0, 1000) * 1000;
                item.Amount = new Random().Next(0, 1000);
                item.CreateAt = start.AddDays(random.Next(range));
            }
            _db.Products.AddRange(products);
            _db.SaveChanges();

            //add status of order
            List<Status> statuses = new()
            {
                new Status { Title = StatusContent.Ordered},
                new Status { Title = StatusContent.DeliveringOrders},
                new Status { Title = StatusContent.OrderReceived},
                new Status { Title = StatusContent.OrderCanceled},
            };
            foreach (var item in statuses)
            {
                _db.Statuses.Add(item);
                _db.SaveChanges();
            }

            //add order
            var userList = _db.Users.ToList();
            var statusList = _db.Statuses.ToList();
            List<Order> orders = new();
            for (int j = 0; j < 10; j++)
            {
                orders.Add(new Order
                {
                    UserId = userList[j].Id,
                    OrderAddress = userList[j].Address,
                    StatusId = new Random().Next(0, statusList.Count) + 1,
                    CreateAt = start.AddDays(random.Next(range))
                });
            }
            _db.Orders.AddRange(orders);
            _db.SaveChanges();

            //add order detail
            var listOrder = _db.Orders.ToList();
            var listProduct = _db.Products.ToList();
            List<OrderDetail> ordersDetail = new();
            int z = 1;
            foreach (Order order in listOrder)
            {
                if (z > listProduct.Count - 10) z = 1;
                for (int j = 0; j < 5; j++)
                {
                    ordersDetail.Add(new OrderDetail
                    {
                        ProductId = listProduct[j + z].Id,
                        OrderId = order.Id,
                        Amount = new Random().Next(0, 20) + 1,
                        PaymentPrice = listProduct[j + z].RecentPrice
                    });
                    ++z;
                }
            }
            _db.OrderDetails.AddRange(ordersDetail);
            _db.SaveChanges();
        }
    }
}
