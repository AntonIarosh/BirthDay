const $form = document.querySelector('#form-div');

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

divEmail = document.createElement('div');
divEmail.classList.add('mb-3');
labelEmail = document.createElement('label');
labelEmail.classList.add('form-label');
labelEmail.innerHTML = "Email";
inputEmail = document.createElement('input');
inputEmail.querySelector='email';
inputEmail.classList.add('form-control');
inputEmail.type ="email";
divEmail.appendChild(labelEmail);
divEmail.appendChild(inputEmail);
$form.appendChild(divEmail);

divPassword = document.createElement('div');
divPassword.classList.add('mb-3');
labelPassword = document.createElement('label');
labelPassword.classList.add('form-label');
labelPassword.innerHTML = "Пароль";
inputPassword = document.createElement('input');
inputPassword.querySelector='password';
inputPassword.classList.add('form-control');
inputPassword.type ="password";
divPassword.appendChild(labelPassword);
divPassword.appendChild(inputPassword);
$form.appendChild(divPassword);

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
divDate.appendChild(labelDate);
divDate.appendChild(inputDate);
$form.appendChild(divDate);

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
divSex.appendChild(labelSex);
divSex.appendChild(select);
$form.appendChild(divSex);

button = document.createElement('button');
button.classList.add('btn');
button.classList.add('btn-primary');
button.innerHTML = "Добавить контакт";
$form.appendChild(button);

button.addEventListener('click', function(e){
    let data = [select.value, inputName.value, inputSecondName.value, 
        inputLastName.value, inputDate.value, inputEmail.value, inputPassword.value];

    let send = {
        "gender": select.value *1,
        "name": inputName.value,
        "secondName": inputSecondName.value,
        "lastName": inputLastName.value,
        "date": inputDate.value,
        "email": inputEmail.value,
        "password": inputPassword.value
    }

    let dataF = new FormData();
    dataF.append("json", JSON.stringify(send));

    function post(url, data) {
            return new Promise((succeed, fail) => {
                const xhr = new XMLHttpRequest();
                xhr.open("POST", url);
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
            .then(response =>  added())
            .catch(error => console.error(error));
  })

  function added() {
    divAdded = document.createElement('div');
    divAdded.classList.add('mb-3');
    labelAdded = document.createElement('label');
    labelAdded.classList.add('form-label');
    labelAdded.innerHTML = "Контакт добавлен!";
    divAdded.appendChild(labelAdded);
    $form.appendChild(divAdded);
  }

  
