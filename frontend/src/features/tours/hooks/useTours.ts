import { useEffect, useState } from "react";
import axios, { AxiosResponse } from "axios";
import { ITour } from "../types/ITour";

export const useTours = (): ITour[] => {
  const [tours, setTours] = useState<ITour[]>([]);
  useEffect(() => {
    fetchTours();
  }, []);

  const fetchTours = async () => {
    const toursData: ITour[] = await axios
      .get("http://localhost:8080/Tours")
      .then((response: AxiosResponse) => response.data);

    setTours(toursData);
  };
  return tours;
};

export const useTour = (id: string): ITour | undefined => {
  const [tourInfo, setTourInfo] = useState<ITour>();
  useEffect(() => {
    fetchTour(id);
  }, [id]);

  const fetchTour = async (id?: string) => {
    debugger;
    if (!id) return;

    debugger;

    const tourInfoData = await axios
      .get(`http://localhost:8080/Tours/${id}`)
      .then((response: AxiosResponse) => response.data);
    debugger;
    if (!tourInfoData) return;

    setTourInfo(tourInfoData);
  };
  return tourInfo;
};

