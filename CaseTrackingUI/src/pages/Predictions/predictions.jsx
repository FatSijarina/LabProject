import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './SuspectDashboard.css';

const SuspectPredictionApp = () => {
    const [suspects, setSuspects] = useState([]);
    const [predictions, setPredictions] = useState({});

    useEffect(() => {
        const fetchSuspects = async () => {
            try {
                const response = await axios.get('https://localhost:7066/api/Suspect/suspects');
                setSuspects(response.data);
                response.data.forEach(suspect => getPrediction(suspect));
            } catch (error) {
                console.error('Error fetching suspects:', error);
            }
        };

        const getPrediction = async (suspect) => {
            const input = mapToPredictionInput(suspect);
            try {
                const predictionResponse = await axios.post('http://127.0.0.1:8000/predict/', input);
                setPredictions(prev => ({ ...prev, [suspect.id]: predictionResponse.data }));
            } catch (error) {
                console.error(`Error predicting for suspect ${suspect.id}:`, error);
            }
        };

        fetchSuspects();
    }, []);

    const mapToPredictionInput = (suspect) => ({
        age: 30,  // Placeholder; adjust based on your data
        previous_criminal_record: suspect.background.includes('criminal') ? 1 : 0,
        history_of_violence: 0,  // Adjust if you have data
        alcohol_use: 0,  // Adjust if you have data
        mental_health_issues: suspect.mentalState === 'Unstable' ? 1 : 0,
        education_level: 'College',  // Adjust if you have data
        social_media_activity: 1,  // Adjust if you have data
        income_stress: 0,  // Adjust if you have data
        relation: 'acquaintance'  // Adjust if you have data
    });

    return (
        <div className="dashboard-container">
            <div className="main-content">
                <h1 className="text-2xl font-bold mb-4">Suspect Prediction</h1>
                {suspects.map(suspect => (
                    <div key={suspect.id} className="suspect-card">
                        <h2>{suspect.name}</h2>
                        <p><strong>Profession:</strong> {suspect.profession}</p>
                        <p><strong>Background:</strong> {suspect.background}</p>
                        <p><strong>Suspicion Level:</strong> {suspect.suspicion}</p>
                        <p className={`prediction ${predictions[suspect.id] === 1 ? 'likely' : 'unlikely'}`}>
                            {predictions[suspect.id] === 1 ? 'Likely Guilty' : 'Unlikely Guilty'}
                        </p>
                    </div>
                ))}
            </div>
        </div>
    );
}    

export default SuspectPredictionApp;
