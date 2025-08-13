import { useTours } from "../hooks/useTours";
import { ITour } from "../types/ITour";
import TourCard from "./TourCard";

const Tours = () => {
  const tours = useTours();

  return (
    <div className={"container"}>
      {tours.map((tour: ITour) => (
        <TourCard
          key={tour.id}
          id={tour.id}
          name={tour.name}
          description={tour.description}
          date={tour.date}
          status={tour.status}
          mountainId={tour.mountainId}
        />
      ))}
    </div>
  );
};

export default Tours;

