import {useParams} from "react-router-dom";
import { useTour } from "../../hooks/useTours";

type TourParam = {
    id: string;
}

const TourInfo = () => {
    const { id } = useParams<TourParam>();
    debugger;
    const tourInfo = useTour(id as string);

    debugger;
    return (
        <div className="max-w-2xl mx-auto p-6">
            <div className="bg-white rounded-xl shadow-lg p-8">
                <h1 className="text-3xl font-bold text-blue-600 mb-4">
                    {tourInfo?.name}
                </h1>
                <h3 className="text-xl text-gray-600 mb-3">
                    {tourInfo?.date}
                </h3>
                <div className="mt-6 pt-6 border-t border-gray-100">
                    <h4 className="text-gray-700 leading-relaxed">
                        {tourInfo?.description}
                    </h4>
                </div>
            </div>
        </div>
    );
}

export default TourInfo;