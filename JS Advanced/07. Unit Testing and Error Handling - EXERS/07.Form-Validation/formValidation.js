function validate() {
    const userFieldset = document.getElementById('userInfo');
    const usernameFIeld = document.getElementById('username');
    const emailField = document.getElementById('email');
    const passwordField = document.getElementById('password');
    const confirmPassField = document.getElementById('confirm-password');

    const checkboxCompany = document.getElementById('company');

    const companyFieldset = document.getElementById('companyInfo');
    const companyNumberField = document.getElementById('companyNumber');

    const submitButton = document.getElementById('submit');

    const validDiv = document.getElementById('valid');

    checkboxCompany.addEventListener('change', (ev) => {
        companyFieldset.style.display = ev.target.checked ? 'block' : 'none';
    });

    submitButton.addEventListener('click', (ev) => {
        ev.preventDefault();
        
        const usernameRegex = /^[a-zA-Z0-9]+$/gm;
        if (usernameRegex.test(usernameFIeld.value) === false ||
            usernameFIeld.value.length < 3 ||
            usernameFIeld.value.length > 20 ||
            usernameFIeld.value === '') {
            usernameFIeld.style.borderColor = 'red';
        } else {
            usernameFIeld.style.border = 'none';
        }

        const emailRegex = /\S+@\S+\.\S+/gm;
        if (emailRegex.test(emailField.value) === false) {
            emailField.style.borderColor = 'red';
        } else {
            emailField.style.border = 'none';
        }

        const passwordRegex = /^(\w)+$/gm;
        if (passwordRegex.test(passwordField.value) === false ||
            passwordField.value.length < 5 ||
            passwordField.value.length > 15 ||
            passwordField.value === '') {
            passwordField.style.borderColor = 'red';
        } else {
            passwordField.style.border = 'none';
        }

        if (passwordRegex.test(confirmPassField.value) === false ||
            confirmPassField.value.length < 5 ||
            confirmPassField.value.length > 15 ||
            confirmPassField.value === '') {
            confirmPassField.style.borderColor = 'red';
        } else {
            confirmPassField.style.border = 'none';
        }

        if (confirmPassField.value !== passwordField.value ||
            confirmPassField.value === '') {
            confirmPassField.style.borderColor = 'red';
        } else {
            confirmPassField.style.border = 'none';
        }

        if (checkboxCompany.checked) {
            if (companyNumberField.value <= 1000 || companyNumberField >= 9999) {
                companyNumberField.style.borderColor = 'red';
            } else {
                companyNumberField.style.border = 'none';
            }
        }

        if (checkboxCompany.checked === false) {
            if (usernameFIeld.style.borderColor === 'red' ||
                emailField.style.borderColor === 'red' ||
                passwordField.style.borderColor === 'red' ||
                confirmPassField.style.borderColor === 'red') {
                validDiv.style.display = 'none';
            } else {
                validDiv.style.display = 'block';
            }
        } else {
            if (usernameFIeld.style.borderColor === 'red' ||
                emailField.style.borderColor === 'red' ||
                passwordField.style.borderColor === 'red' ||
                confirmPassField.style.borderColor === 'red' ||
                companyNumberField.style.borderColor === 'red') {
                validDiv.style.display = 'none';
            } else {
                validDiv.style.display = 'block';
            }
        }
    });
}

// username.val("Pe");
// password.val("12345");
// confirmPassword.val("12346");
// email.val("pesho");
