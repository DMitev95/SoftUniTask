'use strict';
let num = Math.trunc(Math.random() * 20) + 1;
let score = 20;
const displayMessage = function (message) {
  document.querySelector('.message').textContent = message;
};
document.querySelector('.again').addEventListener('click', function () {
  score = 20;
  num = Math.trunc(Math.random() * 20) + 1;
  displayMessage('Start guessing...');
  document.querySelector('.score').textContent = score;
  document.querySelector('.number').style.width = '15rem';
  document.querySelector('body').style.backgroundColor = '#222';
  document.querySelector('.number').textContent = '?';
  document.querySelector('.guess').value = '';
});
const secretNumber = Math.trunc(Math.random() * 20) + 1;
let highscore = document.querySelector('.highscore').textContent;
document.querySelector('.check').addEventListener('click', function () {
  const guess = Number(document.querySelector('.guess').value);
  if (!guess) {
    document.querySelector('.message').textContent = '⛔ No number!';
  } else if (guess == secretNumber) {
    document.querySelector('.message').textContent = '🎉 Correct Number!';
    document.querySelector('.number').textContent = secretNumber;
    document.querySelector('body').style.backgroundColor = 'rgb(167, 216, 144)';
    if (highscore < document.querySelector('.score').textContent) {
      document.querySelector('.highscore').textContent =
        document.querySelector('.score').textContent;
    }
  } else if (guess > secretNumber) {
    document.querySelector('.message').textContent = '☝ Too hight!';
    document.querySelector('.score').textContent -= 1;
  } else if (guess < secretNumber) {
    document.querySelector('.message').textContent = '👇 Too low!';
    document.querySelector('.score').textContent -= 1;
  }
});
