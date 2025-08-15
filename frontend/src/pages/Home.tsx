import { Button } from '../components/ui/button';

const Home = () => {
  return (
    <>
      <h1>Hello world</h1>
      <div className="p-4">
        <Button>Test Button</Button>
        <Button variant="outline" className="ml-2">
          Outline Button
        </Button>
        <Button variant="destructive" className="ml-2">
          Destructive Button
        </Button>
      </div>
    </>
  );
};

export default Home;
