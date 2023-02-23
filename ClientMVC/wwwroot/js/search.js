// Lấy thẻ cha có id="product-list"
const productList = document.getElementById("product-list");
// Lấy danh sách sản phẩm từ server
var urlProducts = "https://localhost:44362/api/Products";

fetch(urlProducts)
    .then((response) => response.json())
    .then((products) => {
        // Duyệt qua danh sách sản phẩm và tạo thẻ con cho từng sản phẩm
        products.forEach((product) => {
            // Tạo thẻ con mới
            const productItem = document.createElement("div");
            productItem.className = "col-lg-4 col-md-6 col-sm-6";
            productItem.innerHTML = `
        <div class="product__item sale">
          <div class="product__item__pic set-bg" data-setbg="img/product-1.jpg">
            <span class="label">Sale</span>
            <ul class="product__hover">
              <li><a href="#"><img src="~/img/icon/heart.png" alt=""></a></li>
              <li><a href="#"><img src="~/img/icon/compare.png" alt=""> <span>Compare</span></a></li>
              <li><a href="#"><img src="~/img/icon/search.png" alt=""></a></li>
            </ul>
          </div>
          <div class="product__item__text">
            <h6>${product.title}</h6>
            <a href="#" class="add-cart">+ Add To Cart</a>
            <div class="rating">
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star-o"></i>
            </div>
            <h5>$${product.recentPrice} VND</h5>
            <div class="product__color__select">
              <label for="pc-7">
                <input type="radio" id="pc-7">
              </label>
              <label class="active black" for="pc-8">
                <input type="radio" id="pc-8">
              </label>
              <label class="grey" for="pc-9">
                <input type="radio" id="pc-9">
              </label>
            </div>
          </div>
        </div>
      `;

            // Thêm thẻ con vào thẻ cha
            productList.appendChild(productItem);
        });
    });
