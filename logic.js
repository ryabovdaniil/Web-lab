document.getElementById("main-form").addEventListener("submit", checkForm)

function checkForm(){
	event.preventDefault();

	var el = document.getElementById("main-form");
 
	var adress = el.adress.value;
	var rooms = el.rooms.value;
	var price = el.price.value;
	var renovation = el.renovation.value;

	var fail = "";

	if (adress == "" || rooms == "" || price == "") {
		fail = "Введите данные";
	}else if (isNaN(rooms) || isNaN(price) || rooms<1) {
		fail = "Некорректные данные";
	}

	if (fail != "") {
		document.getElementById('error').innerHTML = fail;
	}else {

		var list = "Адрес: " + adress +
				 "\nКоличество комнат: " + rooms + 
				 "\nЦена: " + price + 
				 "\nРемонт: " + renovation;

		alert(list);

	}
}