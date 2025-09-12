import './FeedbackDisplay.css';

export default function FeedbackDisplay({ feedback }) {
  return (
    <div className="feedback-display">
      <div className="feedback-card">
        <div className="feedback-header">
          <h3 className="feedback-name">{feedback.name}</h3>
          {feedback.rating > 0 && (
            <div className="feedback-rating">
              <span className="rating-value">{feedback.rating}/5</span>
            </div>
          )}
        </div>
        
        {feedback.feedback && (
          <div className="feedback-content">
            <p>{feedback.feedback}</p>
          </div>
        )}
      </div>
    </div>
  );
};