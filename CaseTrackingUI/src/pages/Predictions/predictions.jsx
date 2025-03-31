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
                setPredictions(prev => ({ 
                    ...prev, 
                    [suspect.id]: { 
                        crime_likelihood: predictionResponse.data.crime_likelihood, 
                        confidence_score: predictionResponse.data.confidence_score, 
                        is_confident: predictionResponse.data.is_confident 
                    }
                }));
            } catch (error) {
                console.error(`Error predicting for suspect ${suspect.id}:`, error);
            }
        };

        fetchSuspects();
    }, []);

    const mapToPredictionInput = (suspect) => ({
        suspicion: getSuspicionLevel(suspect.suspicion),
        previous_criminal_record: suspect.background.toLowerCase().includes('criminal record') ? 1 : 0,
        forensic_evidence: suspect.biologicalTraces.length > 0 ? 1 : 0,
        mental_state: suspect.mentalState.toLowerCase(),
        profession: suspect.profession.toLowerCase()
    });

    const getSuspicionLevel = (suspicion) => {
        if (suspicion.toLowerCase().includes('high')) return 'high';
        if (suspicion.toLowerCase().includes('moderate')) return 'moderate';
        return 'low';
    };

    return (
        <div className="dashboard-container">
            <div className="main-content">
                <h1 className="text-2xl font-bold mb-4">Suspect Prediction</h1>
                {suspects.map(suspect => (
                    <div key={suspect.id} className="suspect-card">
                        <h2>{suspect.name}</h2>
                        <p><strong>Gender:</strong> {suspect.gender}</p>
                        <p><strong>Profession:</strong> {suspect.profession}</p>
                        <p><strong>Status:</strong> {suspect.status}</p>
                        <p><strong>Residence:</strong> {suspect.residence}</p>
                        <p><strong>Mental State:</strong> {suspect.mentalState}</p>
                        <p><strong>Background:</strong> {suspect.background}</p>
                        <p><strong>Suspicion Level:</strong> {suspect.suspicion}</p>
                        <p><strong>Statements:</strong></p>
                        <ul>
                            {suspect.statements.map((statement, index) => (
                                <li key={index}>{statement.dateGiven}: {statement.content}</li>
                            ))}
                        </ul>
                        <p><strong>Forensic Evidence:</strong></p>
                        <ul>
                            {suspect.biologicalTraces.map((trace, index) => (
                                <li key={index}>{trace.name} - {trace.specification}</li>
                            ))}
                        </ul>
                        <p className={`prediction ${predictions[suspect.id]?.crime_likelihood === 1 ? 'likely' : 'unlikely'}`}>
                            {predictions[suspect.id]?.crime_likelihood === 1 ? 'Likely Guilty' : 'Unlikely Guilty'}
                        </p>
                        <p className={`confidence ${predictions[suspect.id]?.is_confident ? 'confident' : 'not-confident'}`}>
                            {predictions[suspect.id]?.confidence_score ? 
                                `Confidence: ${predictions[suspect.id].confidence_score}%` : 
                                'Confidence: Not Available'}
                        </p>
                        {predictions[suspect.id]?.confidence_score < 70 && predictions[suspect.id]?.confidence_score !== undefined && (
                            <p className="not-confident">Not Confident (Below Threshold)</p>
                        )}
                    </div>
                ))}
            </div>
        </div>
    );
};

export default SuspectPredictionApp;
