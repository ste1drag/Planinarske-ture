import MountainCard from '@/features/mountain/components/MountainCard';
import { mountainMocks } from '@/mocks/mountains/mocks';

const mountainMock = mountainMocks[0];

const Mountains = () => {
  return (
    <div className="container mx-auto px-4 py-8">
      <h1 className="text-3xl font-bold mb-6">Mountains</h1>
      <MountainCard mountain={mountainMock} />
    </div>
  );
};

export default Mountains;
