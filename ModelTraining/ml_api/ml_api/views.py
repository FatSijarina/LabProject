from django.shortcuts import HttpResponse
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status
import joblib
import numpy as np
from nltk.sentiment import SentimentIntensityAnalyzer

try:
    MODEL_PATH = "crime_prediction_model.pkl"
    model = joblib.load(MODEL_PATH)
except Exception as e:
    model = None
    print(f"Error loading model: {e}")

relation_mapping = {"friend": 1, "stranger": 2, "relative": 3, "co-worker": 4, "neighbor": 5}
crime_mapping = {"theft": 1, "assault": 2, "fraud": 3, "homicide": 4}

@api_view(['POST'])
def predict(request):
    if model is None:
        return Response({"error": "Model not loaded. Check the file path."}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

    try:
        try:
            age = int(request.data.get("age"))
            previous_criminal_record = int(request.data.get("previous_criminal_record")) 
            history_of_violence = int(request.data.get("history_of_violence"))  
            alcohol_use = int(request.data.get("alcohol_use"))  
            mental_health_issues = int(request.data.get("mental_health_issues"))  
            education_level = request.data.get("education_level", "").strip().lower()
            social_media_activity = int(request.data.get("social_media_activity"))  
            income_stress = int(request.data.get("income_stress"))  
            relation = request.data.get("relation", "").strip().lower()
        except (ValueError, TypeError):
            return Response({"error": "Invalid input format."}, status=status.HTTP_400_BAD_REQUEST)

        # Validate categorical inputs
        relation_mapping = {"family": 1, "friend": 2, "stranger": 3}
        education_mapping = {"none": 0, "high school": 1, "college": 2}

        relation = relation_mapping.get(relation, None)
        education_level = education_mapping.get(education_level, None)

        if relation is None or education_level is None:
            return Response({"error": "Invalid relation or education level."}, status=status.HTTP_400_BAD_REQUEST)

        input_data = np.array([[age, previous_criminal_record, history_of_violence, alcohol_use, 
                                mental_health_issues, education_level, social_media_activity, 
                                income_stress, relation]])

        prediction = model.predict(input_data)[0]

        return Response({"prediction": int(prediction)}, status=status.HTTP_200_OK)

    except Exception as e:
        return Response({"error": str(e)}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

