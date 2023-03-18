//token when login success
var token = 'Bearer ' + document.cookie.replace(/(?:(?:^|.*;\s*)access_token\s*\=\s*([^;]*).*$)|^.*$/, "$1");

//url local of mvc
var urlLocal = 'https://localhost:44310/';
//url api gateway 
var urlAPIGateway = 'https://localhost:44364/api/apigateway/';

//url get products
var urlGetProducts = urlAPIGateway + "Products/GetProducts";
//url update product by id
var urlUpdateProduct = urlAPIGateway + 'Products/UpdateProduct/';

//url user
var urlUser = urlAPIGateway + "Users";
//url get users
var urlGetUsers = urlUser + "/GetUsers";
//url update user info
var urlUpdateInfoUser = urlUser + "/UpdateInfoUser";

//url get order
var urlOrder = urlAPIGateway + "Orders";
//get orders List for user or admin
var urlGetOrdersOfUser = urlOrder + "/GetOrdersOfUser";
//order products in cart
var urlOrderProducts = urlOrder + "/OrderProducts";
//confirm order products status ordered, cancel,...
var urlConfirmOrder = urlOrder + "/ConfirmOrder";

//
var urlGetOrderDetailReceived = urlAPIGateway + "OrderDetails/GetOrderDetailReceived";

//url add review product
var urlAddReview = urlAPIGateway + "Reviews/AddReview";
//url get reviews of product + id
var urlGetReviewsOfProduct = urlAPIGateway + "Reviews/GetReviewsOfProduct/";

//url cart
var urlCart = urlAPIGateway + "Carts";
//url add product to cart
var urlAddProductToCart = urlCart + '/AddProductToCart';
//url delete cart/id
var urlDeleteCart = urlCart + "/";
//url update cart/id
var urlPutCart = urlCart + "/PutCart";
//url check quantity in cart
var urlCheckQuantityCart = urlCart + "/CheckQuantity";

//url register user
var urlPostUser = urlAPIGateway + "Users/PostUser";

//url register user
var urlPostMail = urlAPIGateway + "Mails/PostMail";

//toast message 
var messSuccess = 'Thành công!';
var messError = 'Thất bại thử lại sau!';
var messErrorService = 'Lỗi service!';

var languageTableData = {
    "decimal": "",
    "emptyTable": "Không có dữ liệu",
    "info": "Hiển thị _START_ đến _END_ của _TOTAL_ mục",
    "infoEmpty": "Hiển thị 0 đến 0 của 0 mục",
    "infoFiltered": "(được lọc từ _MAX_ mục)",
    "infoPostFix": "",
    "thousands": ",",
    "lengthMenu": "Hiển thị _MENU_ mục",
    "loadingRecords": "Đang tải...",
    "processing": "Đang xử lý...",
    "search": "Tìm kiếm:",
    "zeroRecords": "Không tìm thấy mục nào phù hợp",
    "paginate": {
        "first": "Đầu tiên",
        "last": "Cuối cùng",
        "next": "Tiếp theo",
        "previous": "Trước đó"
    },
    "aria": {
        "sortAscending": ": Sắp xếp tăng dần",
        "sortDescending": ": Sắp xếp giảm dần"
    }
}

//function call api
function ajaxRequest(url, type, data, beforeSendFunc, successFunc, errorFunc) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        beforeSend: beforeSendFunc,
        contentType: 'application/json',
        dataType: 'json',
        success: successFunc,
        error: errorFunc
    });
}

// Phương thức kiểm tra định dạng email
function isValidEmail(email) {
    var pattern = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return pattern.test(email);
}