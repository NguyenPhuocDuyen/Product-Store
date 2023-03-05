using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _db.Roles.Add(new Role { Description = "Admin" });
            _db.SaveChanges();
            _db.Roles.Add(new Role { Description = "Customer" });
            _db.SaveChanges();

            _db.Users.Add(new User { RoleId = 1, Email = "Admin@gmail.com", Password = "Admin@gmail.com" });
            _db.SaveChanges();

            List<User> users = new()
            {
                new User{RoleId = 2, Email = "Customer1@gmail.com", Password = "Customer1@gmail.com", Address = "Ha Noi"},
                new User{RoleId = 2, Email = "Customer2@gmail.com", Password = "Customer2@gmail.com", Address = "Ho Chi Minh"},
                new User{RoleId = 2, Email = "Customer3@gmail.com", Password = "Customer3@gmail.com", Address = "Da Nang"},
                new User{RoleId = 2, Email = "Customer4@gmail.com", Password = "Customer4@gmail.com", Address = "Hue"},
                new User{RoleId = 2, Email = "Customer5@gmail.com", Password = "Customer5@gmail.com", Address = "Can Tho"},
                new User{RoleId = 2, Email = "Customer6@gmail.com", Password = "Customer6@gmail.com", Address = "Vinh Long"},
                new User{RoleId = 2, Email = "Customer7@gmail.com", Password = "Customer7@gmail.com", Address = "Phu Yen"},
                new User{RoleId = 2, Email = "Customer8@gmail.com", Password = "Customer8@gmail.com", Address = "Dong Thap"},
                new User{RoleId = 2, Email = "Customer9@gmail.com", Password = "Customer9@gmail.com", Address = "Ca Mau"},

                new User{RoleId = 2, Email = "Customer10@gmail.com", Password = "Customer10@gmail.com", Address = "Ha Noi"},
                new User{RoleId = 2, Email = "Customer11@gmail.com", Password = "Customer11@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer12@gmail.com", Password = "Customer12@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer13@gmail.com", Password = "Customer13@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer14@gmail.com", Password = "Customer14@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer15@gmail.com", Password = "Customer15@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer16@gmail.com", Password = "Customer16@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer17@gmail.com", Password = "Customer17@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer18@gmail.com", Password = "Customer18@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer19@gmail.com", Password = "Customer19@gmail.com", Address = "Thanh Hoa"},

                new User{RoleId = 2, Email = "Customer20@gmail.com", Password = "Customer20@gmail.com", Address = "Ho Chi Minh"},
                new User{RoleId = 2, Email = "Customer21@gmail.com", Password = "Customer21@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer22@gmail.com", Password = "Customer22@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer23@gmail.com", Password = "Customer23@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer24@gmail.com", Password = "Customer24@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer25@gmail.com", Password = "Customer25@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer26@gmail.com", Password = "Customer26@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer27@gmail.com", Password = "Customer27@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer28@gmail.com", Password = "Customer28@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer29@gmail.com", Password = "Customer29@gmail.com", Address = "Thanh Hoa"},

                new User{RoleId = 2, Email = "Customer30@gmail.com", Password = "Customer30@gmail.com", Address = "Da Nang"},
                new User{RoleId = 2, Email = "Customer31@gmail.com", Password = "Customer31@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer32@gmail.com", Password = "Customer32@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer33@gmail.com", Password = "Customer33@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer34@gmail.com", Password = "Customer34@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer35@gmail.com", Password = "Customer35@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer36@gmail.com", Password = "Customer36@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer37@gmail.com", Password = "Customer37@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer38@gmail.com", Password = "Customer38@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer39@gmail.com", Password = "Customer39@gmail.com", Address = "Thanh Hoa"},

                new User{RoleId = 2, Email = "Customer40@gmail.com", Password = "Customer40@gmail.com", Address = "Hue"},
                new User{RoleId = 2, Email = "Customer41@gmail.com", Password = "Customer41@gmail.com", Address = "Ba Ria Vung Tau"},
                new User{RoleId = 2, Email = "Customer42@gmail.com", Password = "Customer42@gmail.com", Address = "Bac Lieu"},
                new User{RoleId = 2, Email = "Customer43@gmail.com", Password = "Customer43@gmail.com", Address = "Ben Tre"},
                new User{RoleId = 2, Email = "Customer44@gmail.com", Password = "Customer44@gmail.com", Address = "Binh Duong"},
                new User{RoleId = 2, Email = "Customer45@gmail.com", Password = "Customer45@gmail.com", Address = "Binh Thuan"},
                new User{RoleId = 2, Email = "Customer46@gmail.com", Password = "Customer46@gmail.com", Address = "Gia Lai"},
                new User{RoleId = 2, Email = "Customer47@gmail.com", Password = "Customer47@gmail.com", Address = "Ha Giang"},
                new User{RoleId = 2, Email = "Customer48@gmail.com", Password = "Customer48@gmail.com", Address = "Hau Giang"},
                new User{RoleId = 2, Email = "Customer49@gmail.com", Password = "Customer49@gmail.com", Address = "Thanh Hoa"},
            };
            _db.Users.AddRange(users);
            _db.SaveChanges();

            Random random = new Random();
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;

            List<Product> products = new()
            {
                new Product { CategoryId = 1, UserId = 1, Description="Chiều cao bàn ăn tiêu chuẩn thường nhất quán (trung từ 71 – 76cm), Nhưng quý vị cần cân nhắc khoảng cách khi chúng ta kéo ghế ra ngồi ăn cơm. Đủ không gian cho mọi người ngồi vừa và bắt chéo chân, không quá cao gây cảm giác vướng, khó chịu. Nói chung, khoảng cách từ ghế và bàn ăn cách khoảng 30cm.",Thumbnail="~/Data/Image/ban-tron.jpg", RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn tròn", },
                new Product { CategoryId = 1, UserId = 1, Description="Kích thước bàn: Dài = 120cm ; Rộng = 60cm ; Cao = 75cm.Mặt bàn: Được làm bằng gỗ MDF cao cấp có độ dày 17 li. Mặt bàn phue melamine chống thấm, chống xước và có độ bền đẹp cao.Khung bàn: Được làm bằng sắt có kết cấu chắc chắn. Bên ngoài được sơn phủ bởi lớp sơn tĩnh điện có thẩm mỹ cực cao. Sơn tĩnh điện chống xước, chống han rỉ. Lớp sơn bảo vệ cho khung sắt có độ bền len tới 10 năm.Bàn được đóng hộp carton dày 8 lii chắc chắn và chuyên nghiệp",Thumbnail="~/Data/Image/ban-chu-z.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn chữ Z", },
                new Product { CategoryId = 1, UserId = 1, Description="Kích thước: Dài x Rộng x Cao (120 x 60 x 48/52)cm, Màu sắc: Đỏ, vàng, xanh lá và xanh dương , Chất liệu: Nhựa PP + sắt sơn tĩnh điện chắc chắn, bền đẹp, không phai màu…",Thumbnail="~/Data/Image/ban-nhua.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn Nhựa", },
                new Product { CategoryId = 2, UserId = 1, Description="Kích thước: Cao 55 cm; mặt ghế tròn đường kính 32 cm . Đặc điểm:  + Mặt ghế được tạo hình bằng máy ép thuỷ lực 250 tấn, đường nét sắc sảo, chắc chắn. Có sần chống trơn trượt. Trên mặt dập logo “Inox Nam Việt”. Chân ghế tròn phi 19, sử dụng máy uốn chuyên dụng, nhanh, đẹp, chính xác.Dưới mặt ghế có đệm cao su giúp ghế không bị lõm sau một thời gian sử dụng, không phát ra tiếng kêu khi ngồi như các loại ghế thông thường trên thị trường.Các mối hàn được thực hiện bằng công nghệ hàn TIG có khí Ar bảo vệ chống oxi hóa.",Thumbnail="~/Data/Image/ghe-tron.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế tròn", },
                new Product { CategoryId = 2, UserId = 1, Description="Ghế gỗ tròn gồm có 3 chân nên tạo sự chắc chắn và mạnh mẽ trong từng góc nhìn.Thiết kế cao phù hợp ngồi tại quầy bar, rượu.Ghế 3 chân gỗ có màu nâu gỗ đi cùng với vàng/đỏ ở các chi tiết mặt ghế và chân ghế giúp nổi bật. Thiết kế đơn giản, gọn nhẹ dễ di chuyển và xếp gọn. Mặt ghế ngồi hình tròn bằng nhựa cứng được uốn cong bo xuống tạo thiết kế mềm mại.",Thumbnail="~/Data/Image/ghe-3-chan.jpg", RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế 3 chân", },
                new Product { CategoryId = 2, UserId = 1, Description="Khung gỗ sử dụng thường xuyên nhất đối với các bộ ghế sofa. Cấu tạo khung ghế sofa khá đơn giản. Chúng bao gồm các thanh gỗ được kết nối với nhau. Tạo thành hệ thống trợ lực nâng đỡ cho nhau. Đảm bảo lực được phân tán đều lên các thanh chịu lực. Tránh hiện tượng bị gãy khung khi sử dụng. Với ghế sofa sử dụng khung gỗ thông thường có thể chịu được từ 5-7 người sử dụng cùng lúc hoặc có thể hơn. Tương ứng với trọng lượng người sử dụng từ 350-400kg.",Thumbnail="~/Data/Image/ghe-sofa.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế sofa", },
                new Product { CategoryId = 3, UserId = 1, Description="Là siêu phẫm mang hơi hướng Tây hóa vào thị trường Việt Nam từ nhiều năm nay,hình dáng bên ngoài đẹp, bắt mắt. Nó có nhiều mẫu mã ấn tượng, giường tròn có kết cấu tròn đều,có vài mẫu có kiểu giật nút bắt mắt, nệm bên trong cao 10 phân hay 20 phân tùy theo sở thích gia chủ.",Thumbnail="~/Data/Image/giuong-tron.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường tròn", },
                new Product { CategoryId = 3, UserId = 1, Description="Giường đôi là loại giường được sử dụng phổ biến nhất, dành cho nhiều đối tượng khác nhau, có chiều rộng khoảng từ 1,4m đến 2,2m và chiều dài khoảng 2m.Kích thước phổ biến của loại giường này là 1,8m2m được gọi là King size. Ngoài ra còn có giường đôi có kích thước 1,6m2m (Queen size) và 2m2m hay 2,2m2m (Super king size).",Thumbnail="~/Data/Image/giuong-doi.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường Đôi", },
                new Product { CategoryId = 3, UserId = 1, Description="Sử dụng gỗ tự nhiên để thiết kế giường ngủ sẽ đem đến cho bạn sự chắc chắn, an toàn, tuổi thọ của giường cao. Ngoài ra, giường ngủ bằng gỗ tự nhiên có thể chạm trổ, điêu khắc nhiều kiểu kết hợp cùng các vân gỗ tạo nên sự sang trọng cho căn phòng. Tuy nhiên, sử dụng gỗ tự nhiên thì chi phí cao về vật liệu lẫn gia công.",Thumbnail="~/Data/Image/giuong-go.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giường Gỗ", },
                new Product { CategoryId = 4, UserId = 1, Description="Phong cách: đơn giản và hiện đại. Loại vật liệu: ABS. Please confirm that you can wait. Đây là sản phẩm đặt trước và mất khoảng 7-10 ngày để nhận hàng. Cảm ơn bạn. Shop chúng tôi bảo hành sản phẩm trong vòng 3 ngày kể từ ngày khách hàng nhận được sản phẩm. Shop sẽ đổi sản phẩm hoặc",Thumbnail="~/Data/Image/tu-tron.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ tròn", },
                new Product { CategoryId = 4, UserId = 1, Description="Kích thước: (Rộng 38cm x Sâu 45.5cm x Cao 81cm),Màu sắc: Nhiều màu,Thiết kế: 3 tầng, 3 ngăn kéo,",Thumbnail="~/Data/Image/tu-3-ngan.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ 3 Ngăn", },
                new Product { CategoryId = 4, UserId = 1, Description="Tủ tài liệu sắt đã và đang trở thành nội thất không thể thiếu cho mọi không gian sinh hoạt, làm việc. Tủ sắt mang rất nhiều đặc điểm vượt trội dùng để lưu trữ tài liệu, thông tin của công ty và văn phòng. Hiện nay, có rất nhiều mẫu tủ sắt đựng tài liệu có mặt trên thị trường, mỗi thiết kế lại phù hợp với những không gian, nhiệm vụ khác nhau, làm thế nào để lựa chọn được mẫu tủ phù hợp với văn phòng, khiến nó có thể phát huy được ưu điểm vượt trội",Thumbnail="~/Data/Image/tu-tai-lieu.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ Tài Liệu", },
                new Product { CategoryId = 5, UserId = 1, Description="kệ kho hàng với các tải trọng khác nhau, giúp cho doanh nghiệp, khách hàng có thể lựa chọn thoải mái hơn: kệ trung tải, kệ selective, kệ drive in, kệ double deep, kệ pallet, kệ pallet trượt, kệ sàn…",Thumbnail="~/Data/Image/ke-kho-hang.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ Kho Hàng", },
                new Product { CategoryId = 5, UserId = 1, Description="Kết cấu kệ treo tường không giá đỡ (giấu chân âm kệ) rất chắn chắn và đẹp (không lộ phụ kiện ra ngoài).Gỗ công nghiệp HMR hay còn gọi là MDF lõi xanh chống ẩm. Bề mặt được phủ melamine có khả năng chống trầy xước, chịu nhiệt tốt và dễ dàng vệ sinh. Dễ dàng lắp ráp: Sản phẩm được gia công bằng CNC tự động, các vị trí liên kết đều có độ chuẩn xác nên rất dễ dàng trong quá trình lắp ráp sản phẩm.",Thumbnail="~/Data/Image/ke-go.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ Gỗ", },
                new Product { CategoryId = 5, UserId = 1, Description="Còn được gọi ụ tròn khuyến mãi – một sản phẩm được phân phối và sản xuất với mục đích trưng bày sản phẩm ở các cửa hàng, siêu thị. Tên gọi của kệ cũng bắt nguồn từ hình dáng đặc trưng với những mâm tròn xếp thành tầng.Cấu tạo của kệ siêu thị tròn cũng khá đơn giản, bao gồm mâm đáy, các mâm tầng hình tròn, cột trụ, và các phụ kiện đi kèm. Phần rào chắn bên ngoài sẽ giúp cho sản phẩm trưng bày không bị rơi, đồng thời tăng tính thẩm mỹ cho gian hàng.",Thumbnail="~/Data/Image/ke-tron.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ tròn", },

                new Product { CategoryId = 5, UserId = 1, Description="Bàn trà Hoa lê sản xuất đi theo phong cách hiện đại, đa dạng về mẫu mã dễ dàng phối hợp với bất kỳ mẫu ghế sofa hiện đại nào.Chất liệu chúng tôi sử dụng chủ yếu làm bàn trà.",Thumbnail="~/Data/Image/ban-tra.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn trà", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn ăn cho gia đình người Việt có rất nhiều kiểu hình dáng khác nhau, và tùy theo không gian sống mà chúng ta có những lựa chọn kích thước bàn ăn tiêu chuẩn phù hợp nhất.",Thumbnail="~/Data/Image/ban-an.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn ăn", },
                new Product { CategoryId = 5, UserId = 1, Description="Ghế ăn giá rẻ được làm từ chất liệu gỗ tự nhiên, gỗ công nghiệp đang được khách hàng ưu tiên lựa chọn. Mỗi một loại gỗ lại có đặc điểm riêng thu hút khách hàng.",Thumbnail="~/Data/Image/ghe-an.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế ăn", },
                new Product { CategoryId = 5, UserId = 1, Description="Tủ quần áo âm tường không chỉ tiết kiệm diện tích mà còn có tính thẩm mỹ cao đem lại một phòng ngủ hiện đại, tinh tế nhưng không kém phần sang trọng.",Thumbnail="~/Data/Image/tu-quan-ao.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Tủ quần áo", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn làm việc tại nhà là một đồ dùng nội thất cá nhân, là nơi bạn có thể làm việc với máy tính, đọc sách, làm báo cáo… ",Thumbnail="~/Data/Image/ban-lam-viec.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn làm việc", },
                new Product { CategoryId = 5, UserId = 1, Description="Đôi khi là những chiếc ghế chân quỳ sử dụng trong phòng họp. Ghế làm việc hiện đại thường sử dụng một chân chịu lực duy nhất bên dưới ghế.\r\nGhế văn phòng Hòa Phát là dòng sản phẩm ghế làm việc được thiết kế phù hợp với nhu cầu sử dụng của mọi người, chính vì thế ai cũng có thể sử dụng được, ngay cả khi bạn ngồi thư giản, ngồi làm việc đều có thể sử dụng được.",Thumbnail="~/Data/Image/ghe-van-phong.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế văn phòng", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ Sách Gỗ Trang Trí Để Sàn Cao Cấp với thiết kế mới lạ và vô cùng độc đáo mang vẻ đẹp hiện đại với nhiều tính năng vượt trội đáp ứng đầy đủ nhu cầu khách hàng. Sản phẩm được sử dụng trong trang trí phòng khách, phòng làm việc tại nhà và cả các văn phòng.",Thumbnail="~/Data/Image/ke-sach.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ sách", },
                new Product { CategoryId = 5, UserId = 1, Description="Kệ trang trí đang là một xu hướng được yêu thích, thay thế cho những chiếc tủ cồng kềnh nhằm tiết kiệm diện tích không gian nhằm tối đa hóa nhu cầu sử dụng.",Thumbnail="~/Data/Image/ke-trang-tri.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Kệ trang trí", },
                new Product { CategoryId = 5, UserId = 1, Description="Bàn trang điểm hay còn với tên cái dân dã là bàn phấn. Đây không chỉ là món nội thất tạo điểm nhấn thu hút giúp không gian trở nên sang trọng và tinh tế hơn. Mà bàn trang điểm còn mang lại cho các nàng một góc làm đẹp hoàn hảo.",Thumbnail="~/Data/Image/ban-phan.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn phấn", },
                new Product { CategoryId = 5, UserId = 1, Description="Ghế gỗ mang hình thức đẹp, trang nhã rất thích hợp dùng để trang trí.Sản phẩm có độ bền và chắc chắn, có tuổi thọ cao.Thể hiện được gu thẩm mỹ và phong cách cá nhân của người sử dụng.Rất tiện lợi vì độ gọn nhẹ và dễ dàng sử dụng ở bất kì đâu",Thumbnail="~/Data/Image/ghe-dau.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ghế đẩu", },
                new Product { CategoryId = 5, UserId = 1, Description="bàn Cafe chân sắt với mặt bàn tròn hoặc vuông kích thước từ 60-80cm đa dạng chất liệu mặt bàn như mặt bàn gỗ tre, gỗ me tây nguyên tấm, gỗ cao su,",Thumbnail="~/Data/Image/ban-cafe.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bàn cafe", },
                new Product { CategoryId = 5, UserId = 1, Description="Đèn bàn RD-RL-60 sử dụng chip LED SunLike ánh sáng tương tự ánh sáng mặt trời kết hợp chậu cây tô điểm cho căn phòng, tăng hiệu quả học tập, làm việc.",Thumbnail="~/Data/Image/den-ban.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đèn bàn", },
                new Product { CategoryId = 5, UserId = 1, Description="Đèn trần phòng khách hiện đại 3 màu độc đáo kết hợp công nghệ Led tiết kiêm điện năng và ý tưởng mới lạ của nghệ nhân đèn đã tạo nên tác phẩm xuất sắc.\r\n",Thumbnail="~/Data/Image/den-tran.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "đèn trần", },
                new Product { CategoryId = 5, UserId = 1, Description="Rèm cửa phòng khách là 1 loại phụ kiện quan trọng để hoàn thiện đồ nội thất trong phòng cũng như tạo ra một loại tâm trạng tích cực và không khí vui tươi.\r\n",Thumbnail="~/Data/Image/rem-cua.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "rèm cửa", },
                new Product { CategoryId = 5, UserId = 1, Description="Thảm rối đa hoạ tiết đặc biệt chỉ có kích thước 40x60(cm) nên thảm thích hợp đặt trước cửa nhà riêng, căn hộ, văn phòng, phòng riêng, nhà vệ sinh, phòng tắm,",Thumbnail="~/Data/Image/tham-trai-san.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "thảm trải sàn", },

                new Product { CategoryId = 5, UserId = 1, Description="Mang kiểu dáng và hơi thở của nội thất châu Âu, gương tròn treo tường hoa hướng dương cổ điển được thiết kế tỉ mỉ, tinh tế đến từng chi tiết.",Thumbnail="~/Data/Image/guong-tron.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "gương tròn", },
                new Product { CategoryId = 5, UserId = 1, Description="Một nhà thiết kế lừng danh đã từng nói: “Không có đường biên giới hạn cho sáng tạo nghệ thuật”. Có lẽ bởi tinh thần ấy, mà trong ngành thiết kế nội thất, những mẫu mã sản phẩm luôn có sự vận động, thay đổi không ngừng. Đã qua rồi cách tư duy rập khuôn theo chức năng như gương chỉ để soi, bình chỉ để cắm hoa,… Giờ đây, bất cứ vật phẩm gì trong không gian nội thất cũng được truyền tải nét đẹp thẩm mỹ từ sáng tạo nghệ thuật. Trong bài viết này, chúng tôi muốn giới thiệu đến bạn đọc một sản phẩm như vậy. Đó chính là thiết kế gương nghệ thuật hình tròn – hội tụ tinh hoa của sáng tạo.",Thumbnail="~/Data/Image/guong-tron-nghe-thuat.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "gương tròn nghệ thuật", },
                new Product { CategoryId = 5, UserId = 1, Description="Mang kiểu dáng và hơi thở của nội thất châu Âu, gương tròn treo tường hoa hướng dương cổ điển được thiết kế tỉ mỉ, tinh tế đến từng chi tiết.",Thumbnail="~/Data/Image/guong-treo-tuong.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "gương treo tường", },
                new Product { CategoryId = 5, UserId = 1, Description="Bình hoa gốm Bát Tràng cao cấp cắm hoa vẽ tay thủ công trên nền men mộc vintage trang trí phòng khách đẹp Mộc Gốm MG78",Thumbnail="~/Data/Image/binh-hoa-ve-tay.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bình hoa vẽ tay", },
                new Product { CategoryId = 5, UserId = 1, Description="Bình thủy tinh họa tiết trái cây với chất liệu chính là thủy tinh borosilicate và nhựa ABS an toàn cho sức khỏe. Chiều cao 20cm. Đường kính 6,5cm.",Thumbnail="~/Data/Image/binh-thuy-tinh.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bình thủy tinh", },
                new Product { CategoryId = 5, UserId = 1, Description="Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu",Thumbnail="~/Data/Image/giay-dan-tuong-retro.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giấy dán tường retro", },
                new Product { CategoryId = 5, UserId = 1, Description="Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu",Thumbnail="~/Data/Image/giay-dan-tuong-gia-gach.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giấy dán tường giả gạch", },
                new Product { CategoryId = 5, UserId = 1, Description="Giấy dán tường là vật liệu dùng để trang trí nội thất. Nó có cấu tạo bề mặt dưới là giấy và ở mặt trên là nhựa. Mặt trên được in các hoa văn hoa tiết đầy đủ màu",Thumbnail="~/Data/Image/giay-dan-tuong-den-nham.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Giấy dán tường đen nhám", },
                new Product { CategoryId = 5, UserId = 1, Description="Màu sắc trang trí họa tiết trên bình ngâm rượu thường đơn giản, không lòe loẹt, nhưng vô cùng bắt mắt và tinh sảo. Cấu tạo bên trong và bên ngoài của bình ngâm",Thumbnail="~/Data/Image/binh-ruou-ngam-trang-tri.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bình rượu ngâm trang trí", },
                new Product { CategoryId = 5, UserId = 1, Description="Rượu vang là một thức uống có cồn làm từ nho lên men . Nấm men tiêu thụ đường trong nho và chuyển đổi nó thành ethanol , carbon dioxide và nhiệt. Các giống nho và chủng nấm men khác nhau tạo ra các kiểu rượu khác nhau. Những biến thể này là kết quả của sự tương tác phức tạp giữa sự phát triển sinh hóa của nho, các phản ứng liên quan đến quá trình lên men, terroir và quá trình sản xuất. Nhiều quốc gia ban hành tên gọi pháp lý nhằm xác định phong cách và chất lượng của rượu vang",Thumbnail="~/Data/Image/binh-ruou-vang.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Bình rượu vang", },
                new Product { CategoryId = 5, UserId = 1, Description="Nuôi cá cảnh mini với số lượng vừa đủ. Hồ cá mini nhỏ nên bạn chỉ nuôi vài con, tránh tình trạng cá chết do thiếu oxy và không đủ không gian bơi lội.",Thumbnail="~/Data/Image/ho-ca-mini.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Hồ cá mini", },
                new Product { CategoryId = 5, UserId = 1, Description=" Bể cá thủy sinh luôn mang đến cho mỗi người chúng ta một cảm giác rất đặc biệt về tâm lý và thị giác. Một không gian xanh, tươi mới",Thumbnail="~/Data/Image/ho-ca-thuy-sinh.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Hồ cá thủy sinh", },
                new Product { CategoryId = 5, UserId = 1, Description=" Không gian xanh ngoài trời của gia đình bạn sẽ tăng thêm vẻ đẹp khi có thêm sự xuất hiện của bể cá xi măng. Thiết kế này sẽ giúp khu vườn trông ...",Thumbnail="~/Data/Image/ho-ca-xi-mang.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Hồ cá xi măng", },
                new Product { CategoryId = 5, UserId = 1, Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="~/Data/Image/dong-ho-trang-tri-giot-nuoc.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đồng hồ trang trí giọt nước", },
                new Product { CategoryId = 5, UserId = 1, Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="~/Data/Image/dong-ho-treo-tuong-decor-vuon-chim.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đồng hồ treo tường decor vườn chim", },
                new Product { CategoryId = 5, UserId = 1, Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="~/Data/Image/dong-ho-treo-tuong-3d.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đồng hồ treo tường 3d", },
                new Product { CategoryId = 5, UserId = 1, Description="Ý nghĩa đồng hồ trang trí . Mỗi đồn hồ mang ý nghĩa khác nhau , mang đến không gian thêm đẹp , mang sự may mắn hạnh phúc . và hợp không gian.",Thumbnail="~/Data/Image/dong-ho-treo-tuong-con-thuyen.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đồng hồ treo tường con thuyền", },
                new Product { CategoryId = 5, UserId = 1, Description="Chiếc Ly Đơn Giản/Tinh Tế,",Thumbnail="~/Data/Image/ly-trang-tri.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ly trang trí", },
                new Product { CategoryId = 5, UserId = 1, Description="Chiếc Ly Đơn Giản/Tinh Tế,",Thumbnail="~/Data/Image/ly-su-trang-tri.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Ly sứ trang trí", },
                new Product { CategoryId = 5, UserId = 1, Description="Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc",Thumbnail="~/Data/Image/dia-trang-tri.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đĩa trang trí", },
                new Product { CategoryId = 5, UserId = 1, Description="Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc",Thumbnail="~/Data/Image/dia-chim-cong.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đĩa trang trí hình chim công", },
                new Product { CategoryId = 5, UserId = 1, Description="Mẫu đĩa sứ trang trí này không chỉ đẹp, độc đáo, mang giá trị cao về mặt thẩm mĩ mà còn có ý nghĩa giúp giữ gìn và lưu truyền văn hóa dân tộc",Thumbnail="~/Data/Image/dia-su-trang-tri-gia-co-ve-hoa-cuc.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Đĩa trang trí vẽ hoa cúc", },
                new Product { CategoryId = 5, UserId = 1, Description=" Gây ấn tượng với họa tiết được cách điệu từ nhân vật mang điệu múa dân tộc Chăm, chiếc quạt được trang trí mang đậm tính dân tộc",Thumbnail="~/Data/Image/quat-vai-treo-tuong.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Quạt vải treo tường", },
                new Product { CategoryId = 5, UserId = 1, Description=" Gây ấn tượng với họa tiết được cách điệu từ nhân vật mang điệu múa dân tộc Chăm, chiếc quạt được trang trí mang đậm tính dân tộc",Thumbnail="~/Data/Image/quat-nan-treo-tuong.jpg",RecentPrice = new Random().Next(0, 1000) * 1000, Amount = new Random().Next(0, 1000),CreateAt = start.AddDays(random.Next(range)), Title = "Quạt nan treo tường",
                 },
            };
            _db.Products.AddRange(products);
            _db.SaveChanges();

            List<Status> statuses = new()
            {
                new Status { Title = "Khách đặt đơn hàng"},
                new Status { Title = "Khách hàng đã huỷ đơn hàng"},
                new Status { Title = "Đã chấp nhận đơn hàng và giao hàng"},
                new Status { Title = "Khách đã nhận hàng"},
            };
            _db.Statuses.AddRange(statuses);
            _db.SaveChanges();

            var userList = _db.Users.ToList();
            var statusList = _db.Statuses.ToList();
            List<Order> orders = new();
            foreach (User user in userList)
            {
                if (user.RoleId != 1)
                {
                    orders.Add(new Order
                    {
                        UserId = user.Id,
                        OrderAddress = user.Address,
                        StatusId = new Random().Next(0, statusList.Count) + 1,
                        CreateAt = start.AddDays(random.Next(range))
                    });
                }
            }
            _db.Orders.AddRange(orders);
            _db.SaveChanges();

            var listOrder = _db.Orders.ToList();
            var listProduct = _db.Products.ToList();
            List<OrderDetail> ordersDetail = new();
            foreach (Order order in listOrder)
            {
                foreach (Product product in listProduct)
                {
                    ordersDetail.Add(new OrderDetail
                    {
                        ProductId = product.Id,
                        OrderId = order.Id,
                        Amount = new Random().Next(0, 20) + 1,
                        PaymentPrice = product.RecentPrice
                    });
                }
            }
            _db.OrderDetails.AddRange(ordersDetail);
            _db.SaveChanges();
        }
    }
}
