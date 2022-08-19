const $form = document.querySelector('#search');
const $result = document.querySelector('#result');

$form.classList.add('border');
$form.classList.add('border-primary');
$form.classList.add('border-3');
$form.classList.add('rounded-3');

divName = document.createElement('div');
divName.classList.add('mb-3');
labelName = document.createElement('label');
labelName.classList.add('form-label');
labelName.innerHTML = "Имя";
inputName = document.createElement('input');
inputName.querySelector='name';
inputName.classList.add('form-control');
inputName.type ="text";
divName.appendChild(labelName);
divName.appendChild(inputName);
$form.appendChild(divName);

divSecondName = document.createElement('div');
divSecondName.classList.add('mb-3');
labelSecondName = document.createElement('label');
labelSecondName.classList.add('form-label');
labelSecondName.innerHTML = "Фамилия";
inputSecondName = document.createElement('input');
inputSecondName.querySelector='secondName';
inputSecondName.classList.add('form-control');
inputSecondName.type ="text";
divSecondName.appendChild(labelSecondName);
divSecondName.appendChild(inputSecondName);
$form.appendChild(divSecondName);

divLastName = document.createElement('div');
divLastName.classList.add('mb-3');
labelLastName = document.createElement('label');
labelLastName.classList.add('form-label');
labelLastName.innerHTML = "Отчество";
inputLastName = document.createElement('input');
inputLastName.querySelector='lastName';
inputLastName.classList.add('form-control');
inputLastName.type ="text";
divLastName.appendChild(labelLastName);
divLastName.appendChild(inputLastName);
$form.appendChild(divLastName);

buttonByFIO = document.createElement('button');
buttonByFIO.classList.add('btn');
buttonByFIO.classList.add('btn-primary');
buttonByFIO.innerHTML = "Выполнить поиск";
$form.appendChild(buttonByFIO);

buttonByFIO.addEventListener('click', function(e){
    var xhr = new XMLHttpRequest();
    // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
    xhr.open('GET', 'https://localhost:5001/api/User/UsersByFIO?name=' + inputName.value +'&secondName=' + inputSecondName.value + 
    '&lastName=' + inputLastName.value, false);

    // 3. Отсылаем запрос
    xhr.send();

    // 4. Если код ответа сервера не 200, то это ошибка
    if (xhr.status != 200) {
      // обработать ошибку
      alert( xhr.status + ': ' + xhr.statusText ); // пример вывода: 404: Not Found
    } else {    
      // вывести результат
      let persons = JSON.parse(xhr.responseText);
      createCard(persons);
    }
})

divEmail = document.createElement('div');
divEmail.classList.add('mb-3');
labelEmail = document.createElement('label');
labelEmail.classList.add('form-label');
labelEmail.innerHTML = "Email";
inputEmails = document.createElement('input');
inputEmails.querySelector='email';
inputEmails.classList.add('form-control');
inputEmails.type ="email";
divEmail.appendChild(labelEmail);
divEmail.appendChild(inputEmails);
$form.appendChild(divEmail);

buttonByEmail = document.createElement('button');
buttonByEmail.classList.add('btn');
buttonByEmail.classList.add('btn-primary');
buttonByEmail.innerHTML = "Выполнить поиск";
$form.appendChild(buttonByEmail);

buttonByEmail.addEventListener('click', function(e){
    var xhrByEmail = new XMLHttpRequest();
    // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
    xhrByEmail.open('GET', 'https://localhost:5001/api/User/UsersByEmail?email=' + inputEmails.value, false);

    // 3. Отсылаем запрос
    xhrByEmail.send();

    // 4. Если код ответа сервера не 200, то это ошибка
    if (xhrByEmail.status != 200) {
      // обработать ошибку
      alert( xhrByEmail.status + ': ' + xhrByEmail.statusText ); // пример вывода: 404: Not Found
    } else {    
      // вывести результат
      let persons = JSON.parse(xhrByEmail.responseText);
      console.log(persons);
      createCard(persons);
    }
})


function createCard(persons) {
    let iterator = 1;
    if (persons === null) {
            div = document.createElement('div');
            div.classList.add('border-danger');
            div.classList.add('container');
            divNoPeole = document.createElement('div');
            divNoPeole.className = "col-md-3 p-3 mb-2 bg-info text-white";
            divNoPeole.textContent = "Контакты не найдены";
            div.appendChild(divNoPeole);
            $form.appendChild(div);  
    } else {
        persons.forEach((el) => {
            console.log(el.id);
            div = document.createElement('div');
            div.classList.add('card-body');
            div.classList.add('border');
            div.classList.add('border-primary');
            div.classList.add('border-3');
            div.classList.add('rounded-3');

            divName = document.createElement('div');
            divName.classList.add('mb-3');
            labelName = document.createElement('label');
            labelName.classList.add('form-label');
            labelName.innerHTML = "Имя контакта № [ "+iterator+" ]";
            iterator++;
            inputName = document.createElement('input');
            inputName.querySelector='name';
            inputName.classList.add('form-control');
            inputName.type ="text";
            inputName.value = el.name;
            divName.appendChild(labelName);
            divName.appendChild(inputName);

            divSecondName = document.createElement('div');
            divSecondName.classList.add('mb-3');
            labelSecondName = document.createElement('label');
            labelSecondName.classList.add('form-label');
            labelSecondName.innerHTML = "Фамилия";
            inputSecondName = document.createElement('input');
            inputSecondName.querySelector='secondName';
            inputSecondName.classList.add('form-control');
            inputSecondName.type ="text";
            inputSecondName.value = el.secondName;
            divSecondName.appendChild(labelSecondName);
            divSecondName.appendChild(inputSecondName);

            divLastName = document.createElement('div');
            divLastName.classList.add('mb-3');
            labelLastName = document.createElement('label');
            labelLastName.classList.add('form-label');
            labelLastName.innerHTML = "Отчество";
            inputLastName = document.createElement('input');
            inputLastName.querySelector='lastName';
            inputLastName.classList.add('form-control');
            inputLastName.type ="text";
            inputLastName.value = el.lastName;
            divLastName.appendChild(labelLastName);
            divLastName.appendChild(inputLastName);

            divEmail = document.createElement('div');
            divEmail.classList.add('mb-3');
            labelEmail = document.createElement('label');
            labelEmail.classList.add('form-label');
            labelEmail.innerHTML = "Email";
            inputEmail = document.createElement('input');
            inputEmail.querySelector='email';
            inputEmail.classList.add('form-control');
            inputEmail.type ="email";
            inputEmail.value = el.email;
            divEmail.appendChild(labelEmail);
            divEmail.appendChild(inputEmail);

            divPassword = document.createElement('div');
            divPassword.classList.add('mb-3');
            labelPassword = document.createElement('label');
            labelPassword.classList.add('form-label');
            labelPassword.innerHTML = "Пароль";
            inputPassword = document.createElement('input');
            inputPassword.querySelector= el.password;
            inputPassword.classList.add('form-control');
            inputPassword.type ="password";
            inputPassword.value = el.password;
            divPassword.appendChild(labelPassword);
            divPassword.appendChild(inputPassword);

            divDate = document.createElement('div');
            divDate.classList.add('mb-3');
            labelDate = document.createElement('label');
            labelDate.classList.add('form-label');
            labelDate.innerHTML = "Дата рождения:";
            inputDate = document.createElement('input');
            inputDate.querySelector='date';
            inputDate.classList.add('form-control');
            inputDate.type ="date";
            inputDate.name ="date";
            console.log(el.date);
            inputDate.value = el.date.slice(0, 10)
            divDate.appendChild(labelDate);
            divDate.appendChild(inputDate);

            divSex = document.createElement('div');
            divSex.classList.add('mb-3');
            divSex.classList.add('input-group');
            labelSex = document.createElement('label');
            labelSex.classList.add('input-group-text');
            labelSex.innerHTML = "Ваш пол : ";
            select = document.createElement('select');
            select.querySelector='gender';
            select.classList.add('form-select');
            select.options[0]= new Option("Мужской", "0");
            select.options[1]= new Option("Женский", "1");
            let gender = el.gender;
            let sex;
            if (gender == "Male") {
                select.value = 0;
            } else {
                select.value = 1;
            }
            divSex.appendChild(labelSex);
            divSex.appendChild(select);

            buttonChenge = document.createElement('button');
            buttonChenge.classList.add('btn');
            buttonChenge.classList.add('btn-primary');
            buttonChenge.innerHTML = "Изменить контакт";

            buttonDelete = document.createElement('button');
            buttonDelete.classList.add('btn');
            buttonDelete.classList.add('btn-primary');
            buttonDelete.innerHTML = "Удалить контакт";

            div.appendChild(divName);
            div.appendChild(divSecondName);
            div.appendChild(divLastName);
            div.appendChild(divEmail);
            div.appendChild(divPassword);
            div.appendChild(divDate);
            div.appendChild(divSex);
            div.appendChild(buttonChenge);
            div.appendChild(buttonDelete);
            $form.appendChild(div);

            buttonChenge.addEventListener('click', function(e) {
                let data = [select.value, inputName.value, inputSecondName.value, 
                    inputLastName.value, inputDate.value, inputEmail.value, inputPassword.value];

                let send = {
                    "id": el.id,
                    "gender": select.value *1,
                    "name": inputName.value,
                    "secondName": inputSecondName.value,
                    "lastName": inputLastName.value,
                    "date": inputDate.value,
                    "email": inputEmail.value,
                    "password": inputPassword.value,
                    "birthDayId": el.birthDayId
                }
                console.log(send);

                let dataF = new FormData();
                dataF.append("json", JSON.stringify(send));

                function post(url, data) {
                        return new Promise((succeed, fail) => {
                            const xhr = new XMLHttpRequest();
                            xhr.open("PUT", url);
                            xhr.setRequestHeader("Content-type", "application/json;charset=utf-8");
                            xhr.addEventListener("load", () => {
                                if (xhr.status >=200 && xhr.status < 400)
                                    succeed(xhr.response);
                                else
                                    fail(new Error(`Request failed: ${xhr.statusText}`));
                            });
                            xhr.addEventListener("error", () => fail(new Error("Network error")));
                            xhr.send(data);
                      });
                    }
                    post("https://localhost:5001/api/User", JSON.stringify(send))
                        .then(response =>  done())
                        .catch(error => console.error(error));
            })

            buttonDelete.addEventListener('click', function(e) {
                var xhrDel = new XMLHttpRequest();
                // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
                xhrDel.open('DELETE', 'https://localhost:5001/api/User?id=' + el.id, false);
            
                // 3. Отсылаем запрос
                xhrDel.send();
            
                // 4. Если код ответа сервера не 200, то это ошибка
                if (xhrDel.status != 200) {
                // обработать ошибку
                alert( xhrDel.status + ': ' + xhrDel.statusText ); // пример вывода: 404: Not Found
                } else {    
                // вывести результат
                done();
                }
            })
        })
    }
}

function done() {
    divAdded = document.createElement('div');
    divAdded.classList.add('mb-3');
    labelAdded = document.createElement('label');
    labelAdded.classList.add('form-label');
    labelAdded.innerHTML = "Выполнено";
    divAdded.appendChild(labelAdded);
    div.appendChild(divAdded);
}