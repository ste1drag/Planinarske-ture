import { useState } from 'react';
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

interface RegisterFormProps {
  onToggleToLogin: () => void;
}

export default function RegisterForm({ onToggleToLogin }: RegisterFormProps) {
  const t = useTranslation();
  const { register, isLoading, error, clearError } = useAuthStore();
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [validationError, setValidationError] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    clearError();
    setValidationError('');

    if (password !== confirmPassword) {
      setValidationError('Passwords do not match');
      return;
    }

    if (!phoneNumber.startsWith('+')) {
      setValidationError(
        'Phone number must start with country code (e.g., +1, +381)'
      );
      return;
    }

    await register({
      FirstName: firstName,
      LastName: lastName,
      UserName: username,
      Email: email,
      PhoneNumber: phoneNumber,
      Password: password,
    });

    // Switch to login form on successful registration
    if (!error) {
      onToggleToLogin();
    }
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
          {(error || validationError) && (
            <div className="p-3 bg-red-50 border border-red-200 rounded-md">
              <p className="text-sm text-red-600">{error ?? validationError}</p>
            </div>
          )}
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
                disabled={isLoading}
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
                disabled={isLoading}
              />
            </div>
          </div>
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
            <Label htmlFor="email">{t.emailAddress}</Label>
            <Input
              id="email"
              type="email"
              placeholder={t.enterEmail}
              value={email}
              onChange={e => setEmail(e.target.value)}
              required
              disabled={isLoading}
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="phoneNumber">Phone Number</Label>
            <Input
              id="phoneNumber"
              type="tel"
              placeholder="Enter your phone number"
              value={phoneNumber}
              onChange={e => setPhoneNumber(e.target.value)}
              required
              disabled={isLoading}
            />
            <p className="text-xs text-muted-foreground">
              Must include country code (e.g., +1, +381, +44)
            </p>
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
          <div className="space-y-2">
            <Label htmlFor="confirmPassword">{t.confirmPassword}</Label>
            <Input
              id="confirmPassword"
              type="password"
              placeholder={t.confirmYourPassword}
              value={confirmPassword}
              onChange={e => setConfirmPassword(e.target.value)}
              required
              disabled={isLoading}
            />
          </div>
        </CardContent>
        <CardFooter className="flex flex-col space-y-4">
          <Button type="submit" className="w-full" disabled={isLoading}>
            {isLoading ? 'Creating account...' : t.signUp}
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
