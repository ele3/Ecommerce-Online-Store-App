
// if(document.readyState == 'loading'){
//     document.addEventListener('DOMContentLoaded',ready)
// } else {
//     ready();
// }

////////////////////////////////////////////
// this function remove item from cart
var removeCartItemButtons = document.getElementsByClassName("remove-button");
//console.log(removeCartItemButtons);
for (var i = 0; i < removeCartItemButtons.length; i++) {
    var button = removeCartItemButtons[i];
    button.addEventListener('click', removeCartItem);

}
//this function checks the quantity and update the cart 
var quantityInputs = document.getElementsByClassName("quantity-input");
for (var i = 0; i < quantityInputs.length; i++) {
    var input = quantityInputs[i];
    input.addEventListener('change', quantityChanged);

}

////////////////////////////////////////////


function removeCartItem(event) {
    var buttonClicked = event.target;
    buttonClicked.parentElement.parentElement.remove();
    updateCartTotal();

}


function quantityChanged(event) {
    var input = event.target;
    if ((isNaN(input.value) || input.value <= 0)) {
        input.value = 1;
    }
    updateCartTotal();
}


function updateCartTotal() {
    var cartItemContainer = document.getElementsByClassName("item")[0];
    var cartRows = cartItemContainer.getElementsByClassName("content");
    var total = 0;
    for (var i = 0; i < removeCartItemButtons.length; i++) {
        var cartRow = cartRows[i];//rows we are currently on
        var priceElement = cartRow.getElementsByClassName("cost")[0];
        var quantityElement = cartRow.getElementsByClassName("quantity-input")[0];
        //console.log(priceElement, quantityElement);
        var price = parseFloat(priceElement.innerText.replace('$', ''));
        var quantity = quantityElement.value;
        console.log(price * quantity);
        total = total += (price * quantity);

    }
    // console.log("TOTAL:");
    // console.log(total);
    document.getElementsByClassName("subTotal")[0].innerText = '$' + total;
    document.getElementsByClassName("cartTotal")[0].innerText = '$' + (total + 20.00);

}