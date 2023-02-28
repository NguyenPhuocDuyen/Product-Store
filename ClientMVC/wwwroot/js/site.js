// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




var productApi = 'https://localhost:44362/api/Products';



function start() {
    getProduct(renderProduct);
    handleCreateForm();
}


start();


//Function

function getProduct(callback) {
    fetch(productApi).then(function (response) {
        return response.json();
    }).then(callback);
}

function createProduct(data , callback) {
    var opsiton = {
        method: 'POST',
        headers: {
            'Content-Type':'application/json'
            },
        body: JSON.stringify(data)
    };
    fetch(productApi, opsiton).then(function (response) {
        response.json();
    }).then(callback);

}


function handleDeleteProduct(id) {
    var opsiton = {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
        
    };
    fetch(productApi + '/' +id, opsiton).then(function (response) {
        response.json();
    }).then(function () {
        var productItem = document.querySelector('.product-item-' + id);
        if (productItem) {
            productItem.remove();
        }
    });
}


function renderProduct(products) {
    var listProductBlock = document.querySelector('#list-product');

    var htmls = products.map(function (product) {
        return `
            <li class="product-item-${product.id}">
            
            
            
            
            <p>${product.title}</p>
            <p>${product.recentPrice}</p>
           
            <p>${product.amount}</p>
            <button onclick="handleDeleteProduct(${product.id})">Delete</button>
            
            </li>
        `;

    });

    listProductBlock.innerHTML = htmls.join('');
}

function handleCreateForm() {
    var createBtn = document.querySelector('#create');
    createBtn.onclick = function () {
       // var id = document.querySelector('input[name="id"]').value;
        var title = document.querySelector('input[name="title"]').value;
        var recent_price = document.querySelector('input[name="recent_price"]').value;
        var amount = document.querySelector('input[name="amount"]').value;

        var formData = {
            //id:id,
            title: title,
            recentPrice: recent_price,
            amount: amount
        };
        createProduct(formData, function () {
            getProduct(renderProduct);
        });
    }
}


function UpdateQuantityProduct() {
    var id = $(this).closest('.product__item').data('id');
    var buttons = document.querySelectorAll('#UpdateQuantityProduct');
    buttons.forEach(function (button) {
        button.addEventListener('change', function () {
            var productId = this.dataset.id;
            $.ajax({
                url: 'https://localhost:44362/api/Carts/GetCartsUser',
                type: 'POST',
                data: JSON.stringify({ UserId: '1', ProductId: productId }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    console.log("success", productId);
                    toastr.success('Product added to cart successfully!');
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log('Error: ' + textStatus + ' - ' + errorThrown);
                    toastr.error('Error occurred while adding product to cart!');
                }
            });
        });
    });

}