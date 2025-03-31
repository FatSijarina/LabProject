from django.shortcuts import HttpResponse
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status
import joblib
import numpy as np

THRESHOLD = 0.7  

try:
    MODEL_PATH = "crime_prediction_model.pkl"
    SCALER_PATH = "scaler.pkl"
    model = joblib.load(MODEL_PATH)
    scaler = joblib.load(SCALER_PATH)
except Exception as e:
    model, scaler = None, None
    print(f"Error loading model or scaler: {e}")

suspicion_mapping = {"low": 0, "moderate": 1, "high": 2}
mental_state_mapping = {"stable": 0, "unstable": 1}
profession_mapping = {"construction worker": 0, "unemployed": 1, "office worker": 2, "engineer": 3}

@api_view(['POST'])
def predict(request):
    if model is None or scaler is None:
        return Response({"error": "Model or scaler not loaded. Check the file path."}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

    try:
        try:
            suspicion = request.data.get("suspicion", "").strip().lower()
            previous_criminal_record = int(request.data.get("previous_criminal_record", 0))
            forensic_evidence = int(request.data.get("forensic_evidence", 0))
            mental_state = request.data.get("mental_state", "").strip().lower()
            profession = request.data.get("profession", "").strip().lower()
        except (ValueError, TypeError):
            return Response({"error": "Invalid input format."}, status=status.HTTP_400_BAD_REQUEST)

        suspicion_level = suspicion_mapping.get(suspicion, None)
        mental_state = mental_state_mapping.get(mental_state, None)
        profession = profession_mapping.get(profession, None)

        if None in [suspicion_level, mental_state, profession]:
            return Response({"error": "Invalid categorical inputs."}, status=status.HTTP_400_BAD_REQUEST)

        input_data = np.array([[suspicion_level, previous_criminal_record, forensic_evidence, mental_state, profession]])
        input_data = scaler.transform(input_data)  

        probabilities = model.predict_proba(input_data)[0]
        crime_likelihood = int(probabilities[1] >= THRESHOLD)  
        confidence_score = round(probabilities[1] * 100, 2)  

        return Response({"crime_likelihood": crime_likelihood, "confidence": confidence_score}, status=status.HTTP_200_OK)

    except Exception as e:
        return Response({"error": str(e)}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
