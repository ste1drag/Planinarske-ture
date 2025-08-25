import AppStats from '@/components/home/AppStats';
import CallToActionSection from '@/components/home/CallToActionSection';
import HeroSection from '@/components/home/HeroSection';

const Home = () => {
  return (
    <div className="min-h-screen bg-background">
      <HeroSection />
      <AppStats />
      <CallToActionSection />
    </div>
  );
};

export default Home;
