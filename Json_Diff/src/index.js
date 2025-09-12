"use strict";

import { Diff } from './diff.js';

// DOM Elements
const logo = document.querySelector('#logo');
const userGreeting = document.querySelector('#user-greeting');
const authLink = document.querySelector('#auth-link');
const promoSection = document.querySelector('#promo-section');
const startBtn = document.querySelector('#start-btn');
const loginSection = document.querySelector('#login-section');
const loginBtn = document.querySelector('#login-btn');
const usernameInput = document.querySelector('#username');
const loginError = document.querySelector('#login-error');
const compareSection = document.querySelector('#compare-section');
const oldJsonTextarea = document.querySelector('#old-json');
const newJsonTextarea = document.querySelector('#new-json');
const oldJsonError = document.querySelector('#old-json-error');
const newJsonError = document.querySelector('#new-json-error');
const compareBtn = document.querySelector('#compare-btn');
const resultSection = document.querySelector('#result-section');
const resultPre = document.querySelector('#result');

const getCurrentUser = () => {
    return localStorage.getItem('currentUser');
}

const setCurrentUser = (username) => {
    if (username) {
        localStorage.setItem('currentUser', username);
    } else {
        localStorage.removeItem('currentUser');
    }
    updateUI();
}

const updateUI = () => {
    const user = getCurrentUser();
    
    if (user) {
        userGreeting.textContent = `Hello, ${user}!`;
        userGreeting.classList.remove('hidden');
        authLink.textContent = 'Log out';
        startBtn.classList.remove('hidden');
    } else {
        userGreeting.classList.add('hidden');
        authLink.textContent = 'Log in';
        startBtn.classList.add('hidden');
    }

    promoSection.classList.remove('hidden');
    loginSection.classList.add('hidden');
    compareSection.classList.add('hidden');
    resultSection.classList.add('hidden');

    usernameInput.value = '';
    oldJsonTextarea.value = '';
    newJsonTextarea.value = '';
    clearErrors();
}

const clearErrors = () => {
    loginError.style.display = 'none';
    oldJsonError.style.display = 'none';
    newJsonError.style.display = 'none';
    oldJsonTextarea.classList.remove('error');
    newJsonTextarea.classList.remove('error');
}

const showError = (textarea, errorElement, message) => {
    textarea.classList.add('error');
    errorElement.textContent = message;
    errorElement.style.display = 'block';
    errorElement.classList.add('invalid');
}

const validateJsonInput = (textarea, errorElement) => {
    const value = textarea.value.trim();
    
    if (value === '') {
        showError(textarea, errorElement, 'Обязательное поле');
        return { isValid: false, json: null };
    }

    try {
        const json = JSON.parse(value);
        textarea.classList.remove('error');
        errorElement.style.display = 'none';
        return { isValid: true, json };
    } catch (error) {
        showError(textarea, errorElement, 'Некорректный JSON');
        return { isValid: false, json: null };
    }
}

logo.addEventListener('click', (e) => {
    e.preventDefault();
    updateUI();
});

authLink.addEventListener('click', (e) => {
    e.preventDefault();
    const user = getCurrentUser();
    if (user) {
        setCurrentUser(null);
    } else {
        promoSection.classList.add('hidden');
        loginSection.classList.remove('hidden');
        compareSection.classList.add('hidden');
        resultSection.classList.add('hidden');
        clearErrors();
    }
});

startBtn.addEventListener('click', (e) => {
    e.preventDefault();
    promoSection.classList.add('hidden');
    loginSection.classList.add('hidden');
    compareSection.classList.remove('hidden');
    resultSection.classList.add('hidden');
    clearErrors();
});

loginBtn.addEventListener('click', () => {
    const username = usernameInput.value.trim();
    if (!username) {
        loginError.style.display = 'block';
        loginError.classList.add('required');
        return;
    }

    loginError.style.display = 'none';
    setCurrentUser(username);
});

compareBtn.addEventListener('click', () => {
    clearErrors();

    let hasError = false;

    const oldJsonValidation = validateJsonInput(oldJsonTextarea, oldJsonError);
    if (!oldJsonValidation.isValid) {
        hasError = true;
    }

    const newJsonValidation = validateJsonInput(newJsonTextarea, newJsonError);
    if (!newJsonValidation.isValid) {
        hasError = true;
    }

    if (hasError) return;

    const result = Diff.calculate(oldJsonValidation.json, newJsonValidation.json);
    resultPre.textContent = result;
    resultSection.classList.remove('hidden');
});

updateUI();