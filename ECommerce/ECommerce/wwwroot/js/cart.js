// this function remove item from cart
var removeCartItemButtons = document.getElementsByClassName("remove-button");
console.log(removeCartItemButtons);
for (var i = 0; i < removeCartItemButtons.length; i++) {
    var button = removeCartItemButtons[i];
    button.addEventListener('click', function (event) {
        var buttonClicked = event.target;
        buttonClicked.parentElement.parentElement.remove();
        updateCartTotal();

    })
}

// function updateCartTotal(){
//     var cartItemContainer = document.getElementsByClassName ("");


// }