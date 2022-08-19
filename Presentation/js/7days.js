const $allInDays = document.querySelector('#days');

divDay = document.createElement('div');
divDay.classList.add('mb-3');
labelDay = document.createElement('label');
labelDay.classList.add('form-label');
labelDay.innerHTML = "Введите шаг диапазона дней: ";
inputDay = document.createElement('input');
inputDay.querySelector='day';
inputDay.classList.add('form-control');
inputDay.type ="text";
divDay.appendChild(labelDay);
divDay.appendChild(inputDay);
$allInDays.appendChild(divDay);

button = document.createElement('button');
button.classList.add('btn');
button.classList.add('btn-primary');
button.innerHTML = "Получить контакты";
$allInDays.appendChild(button);

button.addEventListener('click', function(e) {

    var xhr = new XMLHttpRequest();
        // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
        xhr.open('GET', 'https://localhost:5001/api/User/UsersBetweenDays?days=' +inputDay.value, false);

        // 3. Отсылаем запрос
        xhr.send();

        // 4. Если код ответа сервера не 200, то это ошибка
        if (xhr.status != 200) {
          // обработать ошибку
          alert( xhr.status + ': ' + xhr.statusText ); // пример вывода: 404: Not Found
        } else {    
          // вывести результат
          let persons = JSON.parse(xhr.responseText);
          console.log(persons[0]);
            $allInDays.classList.add('card');
            if (persons == null) {
                div = document.createElement('div');
                div.classList.add('border-danger');
                div.classList.add('container');
                divNoPeole = document.createElement('div');
                divNoPeole.className = "col-md-3 p-3 mb-2 bg-info text-white";
                divNoPeole.textContent = "Сегодня именинники отсутсвуют.";
                div.appendChild(divNoPeole);
                $allInDays.appendChild(div);
            } else {
            persons.forEach((el) => {
                div = document.createElement('div');
                div.classList.add('card-body');
                div.classList.add('border');
                div.classList.add('border-primary');
                div.classList.add('border-3');
                div.classList.add('rounded-3');

                divFIO = document.createElement('div');
                divFIO.style.color = 'green';
                divFIO.className = "col-md-6";
                divFIO.textContent = el.name;
                divFIO.textContent += " " + el.secondName;
                divFIO.textContent += " " + el.lastName;

                divEmail = document.createElement('div');
                divEmail.className = "col-md-6";
                divEmail.className = "text-dark";
                divEmail.textContent = el.email;

                divGender = document.createElement('div');
                divGender.className = "col-md-6";
                divGender.className = "text-dark";
                let gender = el.gender;
                let sex;
                if (gender == "Male") {
                  divGender.textContent = 'M';
                } else {
                  divGender.textContent = 'Ж';
                }

                divRow = document.createElement('div');
                divRow.className = "row";
                divDate = document.createElement('div');
                divDate.className = 'col-xs-6';
                divPased = document.createElement('div');
                divPased.className = 'col-xs-6';

                let date = new Date(el.date);
                var options = {
                    year: 'numeric',
                    month: 'long',
                    day: 'numeric',
                    };
                divDate.textContent += "Дата рождения: " + date.toLocaleString("ru", options)
                let now = new Date();
                if (now > date) {
                    divPased.textContent += " ДР уже прошёл";
                }
                divRow.appendChild(divDate);
                divRow.appendChild(divPased);


                div.appendChild(divFIO);
                div.appendChild(divGender);
                div.appendChild(divRow);
                div.appendChild(divEmail);
                $allInDays.appendChild(div);
                //alert(el.name);
            })
            //console.log(persons[0].users);

        }
    }
})