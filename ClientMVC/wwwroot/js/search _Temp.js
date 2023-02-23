window.onload = function() {
    var productListDiv = document.getElementById("product-list");
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function() {
        if (xhr.readyState == XMLHttpRequest.DONE) {
            if (xhr.status == 200) {
                var products = JSON.parse(xhr.responseText);
                for (var i = 0; i < products.length; i++) {
                    var item = products[i];
                    var productItemDiv = document.createElement("div");
                    productItemDiv.classList.add("col-lg-4");
                    productItemDiv.classList.add("col-md-6");
                    productItemDiv.classList.add("col-sm-6");
                    productItemDiv.innerHTML = `
                        <div class="product__item sale">
                            <div class="product__item__pic set-bg" data-setbg="${item.ImageUrl}">
                                <span class="label">${item.IsOnSale ? 'Sale' : ''}</span>
                                <ul class="product__hover">
                                    <li><a href="#"><img src="img/icon/heart.png" alt=""></a></li>
                                    <li><a href="#"><img src="img/icon/compare.png" alt=""> <span>Compare</span></a>
                                    </li>
                                    <li><a href="#"><img src="img/icon/search.png" alt=""></a></li>
                                </ul>
                            </div>
                            <div class="product__item__text">
                                <h6>${item.Title}</h6>
                                <a href="#" class="add-cart">+ Add To Cart</a>
                                <div class="rating">
                                    ${'★'.repeat(item.Rating)}
                                    ${'☆'.repeat(5 - item.Rating)}
                                </div>
                                <h5>$${item.RecentPrice.toFixed(2)}</h5>
                                <div class="product__color__select">
                                    <label for="pc-7">
                                        <input type="radio" id="pc-7"/>
                                    </label>
                                    <label class="active black" for="pc-8">
                                        <input type="radio" id="pc-8"/>
                                    </label>
                                    <label class="grey" for="pc-9">
                                        <input type="radio" id="pc-9"/>
                                    </label>
                                </div>
                            </div>
                        </div>`;
                    productListDiv.appendChild(productItemDiv);
                }
            }
        }
    };
    xhr.open("GET", "/Shop/Products");
    xhr.send();
};