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

interface RegisterFormProps {
  onToggleToLogin: () => void;
}

export default function RegisterForm({ onToggleToLogin }: RegisterFormProps) {
  const t = useTranslation();
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      alert('Passwords do not match');
      return;
    }

    // Handle registration logic here
    console.log('Registration attempt:', {
      firstName,
      lastName,
      email,
      password,
    });
  };

  return (
    <Card className="w-full max-w-md mx-auto">
      <CardHeader className="space-y-1">
        <CardTitle className="text-2xl text-center">{t.signUp}</CardTitle>
        <CardDescription className="text-center">
          {t.createNewAccount}
        </CardDescription>
      </CardHeader>
      <form onSubmit={handleSubmit}>
        <CardContent className="space-y-4">
          <div className="grid grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label htmlFor="firstName">{t.firstName}</Label>
              <Input
                id="firstName"
                type="text"
                placeholder={t.enterFirstName}
                value={firstName}
                onChange={e => setFirstName(e.target.value)}
                required
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="lastName">{t.lastName}</Label>
              <Input
                id="lastName"
                type="text"
                placeholder={t.enterLastName}
                value={lastName}
                onChange={e => setLastName(e.target.value)}
                required
              />
            </div>
          </div>
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
          <div className="space-y-2">
            <Label htmlFor="confirmPassword">{t.confirmPassword}</Label>
            <Input
              id="confirmPassword"
              type="password"
              placeholder={t.confirmYourPassword}
              value={confirmPassword}
              onChange={e => setConfirmPassword(e.target.value)}
              required
            />
          </div>
        </CardContent>
        <CardFooter className="flex flex-col space-y-4">
          <Button type="submit" className="w-full">
            {t.signUp}
          </Button>
          <p className="text-center text-sm text-gray-600">
            {t.alreadyHaveAccount}{' '}
            <button
              type="button"
              onClick={onToggleToLogin}
              className="font-medium text-forest-light hover:text-forest-dark"
            >
              {t.signIn}
            </button>
          </p>
        </CardFooter>
      </form>
    </Card>
  );
}
