import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuthStore } from '../store/auth-store';
import { Button } from '@/components/ui/Button';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/Card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { useTranslation } from '@/contexts/TranslationContext';

interface LoginFormProps {
  onToggleToRegister: () => void;
}

export default function LoginForm({ onToggleToRegister }: LoginFormProps) {
  const t = useTranslation();
  const navigate = useNavigate();
  const { login, isLoading, error, clearError } = useAuthStore();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    clearError();

    await login({
      UserName: username,
      Password: password,
    });

    // Navigate to home on successful login
    if (!error) {
      navigate('/home');
    }
  };

  return (
    <Card className="w-full max-w-md mx-auto">
      <CardHeader className="space-y-1">
        <CardTitle className="text-2xl text-center">{t.signIn}</CardTitle>
        <CardDescription className="text-center">
          {t.signInToAccount}
        </CardDescription>
      </CardHeader>
      <form onSubmit={handleSubmit}>
        <CardContent className="space-y-4">
          {error && (
            <div className="p-3 bg-red-50 border border-red-200 rounded-md">
              <p className="text-sm text-red-600">{error}</p>
            </div>
          )}
          <div className="space-y-2">
            <Label htmlFor="username">Username</Label>
            <Input
              id="username"
              type="text"
              placeholder="Enter username"
              value={username}
              onChange={e => setUsername(e.target.value)}
              required
              disabled={isLoading}
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="password">{t.password}</Label>
            <Input
              id="password"
              type="password"
              placeholder={t.enterPassword}
              value={password}
              onChange={e => setPassword(e.target.value)}
              required
              disabled={isLoading}
            />
          </div>
        </CardContent>
        <CardFooter className="flex flex-col space-y-4">
          <Button type="submit" className="w-full m-5" disabled={isLoading}>
            {isLoading ? 'Signing in...' : t.signIn}
          </Button>
          <p className="text-center text-sm text-gray-600">
            {t.dontHaveAccount}{' '}
            <button
              type="button"
              onClick={onToggleToRegister}
              className="font-medium ,text-forest-light hover:text-forest-dark"
            >
              {t.signUp}
            </button>
          </p>
        </CardFooter>
      </form>
    </Card>
  );
}
