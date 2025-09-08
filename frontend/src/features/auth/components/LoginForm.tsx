import { useState } from 'react';
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
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Handle login logic here
    console.log('Login attempt:', { email, password });
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
          <div className="space-y-2">
            <Label htmlFor="email">{t.emailAddress}</Label>
            <Input
              id="email"
              type="email"
              placeholder={t.enterEmail}
              value={email}
              onChange={e => setEmail(e.target.value)}
              required
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
            />
          </div>
        </CardContent>
        <CardFooter className="flex flex-col space-y-4">
          <Button type="submit" className="w-full">
            {t.signIn}
          </Button>
          <p className="text-center text-sm text-gray-600">
            {t.dontHaveAccount}{' '}
            <button
              type="button"
              onClick={onToggleToRegister}
              className="font-medium text-forest-light hover:text-forest-dark"
            >
              {t.signUp}
            </button>
          </p>
        </CardFooter>
      </form>
    </Card>
  );
}
