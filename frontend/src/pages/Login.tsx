import { useState } from 'react';
import { useTranslation } from '@/contexts/TranslationContext';
import LoginForm from '@/features/auth/components/LoginForm';
import RegisterForm from '@/features/auth/components/RegisterForm';

const Login = () => {
  const t = useTranslation();
  const [isLogin, setIsLogin] = useState(true);

  const toggleToRegister = () => setIsLogin(false);
  const toggleToLogin = () => setIsLogin(true);

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col justify-center py-12 sm:px-6 lg:px-8">
      <div className="sm:mx-auto sm:w-full sm:max-w-md">
        <div className="text-center mb-8">
          <h1 className="text-3xl font-bold text-gray-900">
            Mountain<span className="text-forest-light">Tours</span>
          </h1>
          <p className="mt-2 text-sm text-gray-600">{t.appTagline}</p>
        </div>

        {isLogin ? (
          <LoginForm onToggleToRegister={toggleToRegister} />
        ) : (
          <RegisterForm onToggleToLogin={toggleToLogin} />
        )}
      </div>
    </div>
  );
};

export default Login;
