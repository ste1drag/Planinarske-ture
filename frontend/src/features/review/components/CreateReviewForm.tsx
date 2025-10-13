import { Star } from 'lucide-react';
import { useState } from 'react';
import { Button } from '@/components/ui/Button';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { Textarea } from '@/components/ui/textarea';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '@/components/ui/Select';
import { CreateReviewDto } from '../types/ReviewDto';

interface CreateReviewFormProps {
  tourId: string;
  userId: number;
  onSubmit: (reviewData: CreateReviewDto) => Promise<void>;
  onCancel: () => void;
}

export default function CreateReviewForm({
  tourId,
  userId,
  onSubmit,
  onCancel,
}: CreateReviewFormProps) {
  const [title, setTitle] = useState('');
  const [comment, setComment] = useState('');
  const [score, setScore] = useState<number>(5);
  const [difficulty, setDifficulty] = useState<number | undefined>(undefined);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);

    if (!title.trim()) {
      setError('Title is required');
      return;
    }

    setIsSubmitting(true);

    try {
      const reviewData: CreateReviewDto = {
        userId,
        tourId,
        title: title.trim(),
        comment: comment.trim() || undefined,
        score,
        difficulty,
      };

      await onSubmit(reviewData);
    } catch (err: any) {
      // Handle validation errors from backend
      if (err?.response?.data?.errors) {
        const errorMessages = Object.values(err.response.data.errors)
          .flat()
          .join(', ');
        setError(errorMessages);
      } else if (err?.response?.data?.title) {
        setError(err.response.data.title);
      } else {
        setError(
          err instanceof Error ? err.message : 'Failed to submit review'
        );
      }
      setIsSubmitting(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      {error && (
        <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded">
          {error}
        </div>
      )}

      <div className="space-y-2">
        <Label htmlFor="title">
          Title <span className="text-red-500">*</span>
        </Label>
        <Input
          id="title"
          value={title}
          onChange={e => setTitle(e.target.value)}
          placeholder="Summarize your experience"
          disabled={isSubmitting}
          required
        />
      </div>

      <div className="space-y-2">
        <Label htmlFor="score">Rating</Label>
        <div className="flex items-center gap-2">
          {[1, 2, 3, 4, 5].map(value => (
            <button
              key={value}
              type="button"
              onClick={() => setScore(value)}
              disabled={isSubmitting}
              className="focus:outline-none transition-transform hover:scale-110"
            >
              <Star
                className={`h-8 w-8 ${
                  value <= score
                    ? 'fill-yellow-500 text-yellow-500'
                    : 'text-gray-300'
                }`}
              />
            </button>
          ))}
          <span className="ml-2 text-sm text-gray-600">{score} / 5</span>
        </div>
      </div>

      <div className="space-y-2">
        <Label htmlFor="difficulty">Difficulty (Optional)</Label>
        <Select
          value={difficulty?.toString()}
          onValueChange={value =>
            setDifficulty(value ? parseInt(value) : undefined)
          }
          disabled={isSubmitting}
        >
          <SelectTrigger>
            <SelectValue placeholder="Select difficulty level" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="1">Very Easy</SelectItem>
            <SelectItem value="2">Easy</SelectItem>
            <SelectItem value="3">Medium</SelectItem>
            <SelectItem value="4">Hard</SelectItem>
            <SelectItem value="5">Very Hard</SelectItem>
          </SelectContent>
        </Select>
      </div>

      <div className="space-y-2">
        <Label htmlFor="comment">Comment (Optional)</Label>
        <Textarea
          id="comment"
          value={comment}
          onChange={e => setComment(e.target.value)}
          placeholder="Share your thoughts about the tour..."
          rows={4}
          disabled={isSubmitting}
        />
      </div>

      <div className="flex gap-3 justify-end pt-4">
        <Button
          type="button"
          variant="outline"
          onClick={onCancel}
          disabled={isSubmitting}
        >
          Cancel
        </Button>
        <Button type="submit" disabled={isSubmitting}>
          {isSubmitting ? 'Submitting...' : 'Submit Review'}
        </Button>
      </div>
    </form>
  );
}
