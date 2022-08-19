document.onreadystatechange = function loadPhones() {
    const date = new Date();
    let month = date.getMonth();
    month = month*1 +1 ;	
    let day = date.getDate();
    const $today = document.querySelector('#today');

        var xhr = new XMLHttpRequest();
        // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
        xhr.open('GET', 'https://localhost:5001/api/BirthDay/GetByDayAndMonth?day=' +day+'&month='+month, false);
        //xhr.open('GET', 'https://localhost:44359/api/BirthDay/GetByDayAndMonth?day=' +8+'&month='+8, false);
        console.log('https://localhost:44359/api/BirthDay/GetByDayAndMonth?day=' +day+'&month='+month);

        // 3. Отсылаем запрос
        xhr.send();

        // 4. Если код ответа сервера не 200, то это ошибка
        if (xhr.status != 200) {
          // обработать ошибку
          alert( xhr.status + ': ' + xhr.statusText ); // пример вывода: 404: Not Found
        } else {
          // вывести результат
          let persons = JSON.parse(xhr.responseText);
            $today.textContent = "";
            $today.classList.add('card');
            if (persons[0] == null) {
                div = document.createElement('div');
                div.classList.add('border-danger');
                div.classList.add('container');
                divNoPeole = document.createElement('div');
                divNoPeole.className = "col-md-3 p-3 mb-2 bg-info text-white";
                divNoPeole.textContent = "Сегодня именинники отсутсвуют.";
                div.appendChild(divNoPeole);
                $today.appendChild(div);
            } else {
            persons[0].users.forEach((el) => {
                div = document.createElement('div');
                div.classList.add('card-body');

                divFIO = document.createElement('div');
                divFIO.style.color = 'green';
                divFIO.className = "col-md-6";
                divDate = document.createElement('div');
                divDate.className = 'col-md-6';
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

                let date = new Date(el.date);
                var options = {
                    year: 'numeric',
                    month: 'long',
                    day: 'numeric',
                    };
                divDate.textContent += "Дата рождения: " + date.toLocaleString("ru", options)
                div.appendChild(divFIO);
                div.appendChild(divGender);
                div.appendChild(divDate);
                div.appendChild(divEmail);
                $today.appendChild(div);
                //alert(el.name);
            })
            console.log(persons[0].users);
            }
        }
    }