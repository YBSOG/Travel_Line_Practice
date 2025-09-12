import React, { useState } from 'react';
import './FeedbackForm.css';

export default function FeedbackForm({ onSubmit }) {
  const [name, setName] = useState('');
  const [rating, setRating] = useState(0);
  const [feedback, setFeedback] = useState('');
  const [isSubmitted, setIsSubmitted] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    
    if (!name.trim()) return;

    const feedbackData = {
      name: name.trim(),
      rating,
      feedback: feedback.trim(),
      date: new Date().toLocaleDateString('ru-RU')
    };

    onSubmit(feedbackData);
    setName('');
    setRating(0);
    setFeedback('');
    setIsSubmitted(true);
    
    setTimeout(() => setIsSubmitted(false), 1500);
  };

  if (isSubmitted) {
    return (
      <div className="feedback-form success-message">
        <h3>Спасибо за ваш отзыв!</h3>
      </div>
    );
  }

  return (
    <form className="feedback-form" onSubmit={handleSubmit}>
      <div className="form-group">
        <label className="form-label">Как вас зовут?</label>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Введите ваше имя"
          className="name-input"
          required
        />
      </div>

      <div className="form-group">
        <label className="form-label">Оценка</label>
        <div className="rating-container">
          <div className="rating-buttons">
            {[1, 2, 3, 4, 5].map((star) => (
              <button
                key={star}
                type="button"
                className={`rating-btn ${rating === star ? 'active' : ''}`}
                onClick={() => setRating(star)}
              >
                {star}
              </button>
            ))}
          </div>
          <div className="rating-display">{rating}/5</div>
        </div>
      </div>

      <div className="form-group">
        <label className="form-label">Напишите, что понравилось, что было непонятно</label>
        <textarea
          value={feedback}
          onChange={(e) => setFeedback(e.target.value)}
          placeholder="Поделитесь вашими впечатлениями..."
          className="feedback-textarea"
          rows="4"
        />
      </div>

      <button type="submit" className="submit-btn">
        ОТПРАВИТЬ
      </button>
    </form>
  );
};