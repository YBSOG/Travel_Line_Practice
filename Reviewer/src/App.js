import React, { useState } from 'react';
import FeedbackForm from './components/FeedbackForm';
import FeedbackDisplay from './components/FeedbackDisplay';
import './App.css';

export default function App() {
  const [lastFeedback, setLastFeedback] = useState(null);

  const handleFeedbackSubmit = (feedback) => {
    setLastFeedback(feedback);
  };

  return (
    <div className="app">
      <div className="container">
        <h1>Помогите нам сделать процесс бронирования лучше</h1>
        <FeedbackForm onSubmit={handleFeedbackSubmit} />
        {lastFeedback && <FeedbackDisplay feedback={lastFeedback} />}
      </div>
    </div>
  );
}