import React from "react";
import { Grid, Container, Box, Typography, Paper } from "@mui/material";
import { ResponsiveBar } from "@nivo/bar";
import { ResponsiveChoroplethCanvas  } from "@nivo/geo";
import worldCountries from "./world_countries.json";

const Statistics = () => {
  const barChartData = [
    {
      category: "United States",
      CrimeIndex: 49.24,
    },
    {
      category: "China",
      CrimeIndex: 25.76,
    },
    {
      category: "United Kingdom",
      CrimeIndex: 46.94,
    },
    {
      category: "Russia",
      CrimeIndex: 39.7,
    },
    {
      category: "Germany",
      CrimeIndex: 38.04,
    },
    {
      category: "France",
      CrimeIndex: 54.56,
    },
    {
      category: "Japan",
      CrimeIndex: 22.89,
    },
    {
      category: "Italy",
      CrimeIndex: 47.31,
    },
    {
      category: "Canada",
      CrimeIndex: 44.78,
    },
  ];

  const mapData = [
    {
      id: "AFG",
      value: 78.4,
    },
    {
      id: "ALB",
      value: 45.4,
    },
    {
      id: "ARG",
      value: 64.0,
    },
    {
      id: "ARM",
      value: 21.6,
    },
    {
      id: "AUT",
      value: 27.6,
    },
    {
      id: "AZE",
      value: 31.7,
    },
    {
      id: "BEL",
      value: 48.9,
    },
    {
      id: "BIH",
      value: 42.5,
    },
    {
      id: "BLR",
      value: 51.4,
    },
    {
      id: "BOL",
      value: 62.0,
    },
    {
      id: "CAN",
      value: 44.8,
    },
    {
      id: "CHL",
      value: 58.7,
    },
    {
      id: "CHN",
      value: 25.8,
    },
    {
      id: "COL",
      value: 60.8,
    },
    {
      id: "CZE",
      value: 26.8,
    },
    {
      id: "DEU",
      value: 38.0,
    },
    {
      id: "EGY",
      value: 47.0,
    },
    {
      id: "ESP",
      value: 35.8,
    },
    {
      id: "FIN",
      value: 26.5,
    },
    {
      id: "FRA",
      value: 54.6,
    },
    {
      id: "GBR",
      value: 46.9,
    },
    {
      id: "GRC",
      value: 46.5,
    },
    {
      id: "HUN",
      value: 33.8,
    },
    {
      id: "IND",
      value: 44.4,
    },
    {
      id: "IRL",
      value: 46.1,
    },
    {
      id: "IRN",
      value: 49.8,
    },
    {
      id: "IRQ",
      value: 46.0,
    },
    {
      id: "ISR",
      value: 32.2,
    },
    {
      id: "ITA",
      value: 47.3,
    },
    {
      id: "JPN",
      value: 22.9,
    },
    {
      id: "USA",
      value: 49.2,
    },
    {
      id: "MEX",
      value: 54.1,
    },
    {
      id: "UY",
      value: 51.9,
    },
    ,
    {
      id: "RUS",
      value: 39.7,
    },
    {
      id: "AUS",
      value: 46.7,
    },
    {
      id: "SOM",
      value: 66.7,
    },
    {
      id: "VEN",
      value: 82.1,
    },
    {
      id: "SAU",
      value: 24.3,
    },
    {
      id: "MAR",
      value: 47.09,
    },
    {
      id: "TUR",
      value: 40.16,
    },
    {
      id: "KEN",
      value: 56.77,
    },
    {
      id: "DZA",
      value: 51.4,
    },
    
    {
      id: "LBY",
      value: 60.36,
    },
    {
      id: "CHE",
      value: 24.87,
    },
    {
      id: "ZAF",
      value: 75.55,
    },
    {
      id: "VEN",
      value: 82.1,
    },
    {
      id: "URY",
      value: 51.92,
    },
    {
      id: "HND",
      value: 74.31,
    },
    {
      id: "NIC",
      value: 50.25,
    },
    {
      id: "BRA",
      value: 66.13,
    },
    {
      id: "PER",
      value: 67.53,
    },
    {
      id: "PRY",
      value: 50.56,
    },
    {
      id: "NGA",
      value: 65.8,
    },
    {
      id: "SDN",
      value: 45.46,
    },
    {
      id: "NOR",
      value: 32.46,
    },
    {
      id: "SWE",
      value: 48.14,
    },
    {
      id: "NLD",
      value: 26.15,
    },
    {
      id: "GBR",
      value: 46.94,
    },
    {
      id: "MNG",
      value: 53.5,
    },
    {
      id: "KAZ",
      value: 46.4,
    },
    {
      id: "CIV",
      value: 57.5,
    },
    {
      id: "GHA",
      value: 44.15,
    },
    {
      id: "BGR",
      value: 37.5,
    },
    {
      id: "NAM",
      value: 64.64,
    },
    {
      id: "AGO",
      value: 65.82,
    },
    {
      id: "MOZ",
      value: 63.7,
    },
    {
      id: "BWA",
      value: 52.64,
    },
    {
      id: "PNG",
      value: 80.38,
    },
    {
      id: "IDN",
      value: 45.93,
    },
    {
      id: "HTI",
      value: 78.3,
    },
    {
      id: "POL",
      value: 29.19,
    },
    {
      id: "ZMB",
      value: 47.89,
    },
    {
      id: "ZWE",
      value: 60.57,
    },
    {
      id: "TZA",
      value: 54.4,
    },
    {
      id: "KEN",
      value: 56.77,
    },
    {
      id: "UGA",
      value: 55.85,
    },
    {
      id: "UKR",
      value: 46.82,
    },
    {
      id: "PRT",
      value: 30.65,
    },
    {
      id: "ETH",
      value: 51.39,
    },
    {
      id: "SYR",
      value: 69.08,
    },
    {
      id: "NZL",
      value: 47.14,
    },
    {
      id: "TWN",
      value: 16.1,
    },
    {
      id: "MYS",
      value: 51.61,
    },
    {
      id: "PHL",
      value: 42.64,
    },
    {
      id: "KHM",
      value: 52.99,
    },
    {
      id: "THA",
      value: 38.32,
    },
    {
      id: "MMR",
      value: 50.05,
    },
    {
      id: "VNM",
      value: 44.09,
    },
    {
      id: "PAK",
      value: 42.83,
    },
    {
      id: "TUN",
      value: 44.69,
    },
    {
      id: "OMN",
      value: 19.64,
    },
    {
      id: "JOR",
      value: 40.74,
    },
    {
      id: "HRV",
      value: 26.1,
    },
    {
      id: "HUN",
      value: 33.78,
    },
    {
      id: "SRB",
      value: 38.48,
    },
    {
      id: "ROU",
      value: 32.81,
    },
    {
      id: "DNK",
      value: 26.64,
    },
    {
      id: "SVN",
      value: 24.24,
    },
    {
      id: "SVK",
      value: 31.33,
    },
    {
      id: "KGZ",
      value: 53.95,
    },
    {
      id: "UZB",
      value: 31.3,
    },
    {
      id: "ISL",
      value: 25.01,
    },
    {
      id: "KOR",
      value: 25.34,
    },
    {
      id: "NIC",
      value: 50.25,
    },
    {
      id: "GTM",
      value: 60.08,
    },
    {
      id: "CUB",
      value: 32.18,
    },
    {
      id: "CRI",
      value: 53.7,
    },
    {
      id: "PAN",
      value: 44.09,
    },
    {
      id: "ECU",
      value: 60.69,
    },
    {
      id: "CMR",
      value: 64.15,
    },
    {
      id: "ARE",
      value: 14.64,
    },
    {
      id: "BGD",
      value: 62.47,
    },
    {
      id: "LKA",
      value: 42.17,
    },
    {
      id: "NPL",
      value: 37.51,
    },
    {
      id: "EST",
      value: 24.47,
    },
    {
      id: "LVA",
      value: 37.33,
    },
    {
      id: "LTU",
      value: 33.2,
    },
    {
      id: "GEO",
      value: 26.24,
    },
    {
      id: "MKD",
      value: 40.7,
    },
    {
      id: "FJI",
      value: 56.65,
    },
    {
      id: "OSA",
      value: 40.2,
    },
    {
      id: "SEN",
      value: 38.66,
    },
    {
      id: "MRT",
      value: 59.32,
    },
    {
      id: "CAF",
      value: 82.69,
    },
  ];

  return (
    <div>
      <Container maxWidth="md">
        <Box textAlign="center" marginTop={4}>
          <Typography
            variant="h4"
            gutterBottom
            style={{ fontFamily: "Poppins", marginBottom: " 1em" }}
          >
            Statistics
          </Typography>
        </Box>
        <Grid container spacing={4}>
          <Grid item xs={12}>
            <Paper>
              <Box textAlign="center">
                <Typography
                  variant="h6"
                  gutterBottom
                  style={{ fontFamily: "Poppins" }}
                >
                  Crime Index Index By Country 2023 Mid-Year
                </Typography>
              </Box>
              <Box height={400} padding={3}>
                <ResponsiveBar
                  data={barChartData}
                  keys={["CrimeIndex"]}
                  indexBy="category"
                  margin={{ top: 10, right: 130, bottom: 50, left: 60 }}
                  padding={0.3}
                  colors="#00176A"
                  axisBottom={{
                    tickSize: 5,
                    tickPadding: 5,
                    tickRotation: 0,
                  }}
                  axisLeft={{
                    tickSize: 5,
                    tickPadding: 5,
                    tickRotation: 0,
                    legend: "Crime Index",
                    legendPosition: "middle",
                    legendOffset: -40,
                  }}
                  labelSkipWidth={12}
                  labelSkipHeight={12}
                  labelTextColor={{
                    from: "color",
                    modifiers: [["darker", 1.6]],
                  }}
                  animate={true}
                  motionStiffness={90}
                  motionDamping={15}
                />
              </Box>
            </Paper>
          </Grid>
          <Grid item xs={12} marginBottom={5}>
            <Paper>
              <Box textAlign="center">
                <Typography
                  variant="h6"
                  gutterBottom
                  style={{ fontFamily: "Poppins" }}
                >
                  Crime Index by Country 2023 Mid-Year
                </Typography>
              </Box>
              <Box height={400} padding={3}>
              <ResponsiveChoroplethCanvas
              data={mapData}
              features={worldCountries.features}
              margin={{ top: 0, right: 0, bottom: 0, left: 0 }}
              colors="spectral"
              domain={[0, 100]} // Adjusted domain to 0-100
              unknownColor="#101b42"
              label="properties.name"
              valueFormat=".1f" // Display decimal numbers with 1 decimal place
              projectionTranslation={[0.5, 0.5]}
              projectionRotation={[0, 0, 0]}
              enableGraticule={true}
              graticuleLineColor="rgba(0, 0, 0, .2)"
              borderWidth={0.5}
              borderColor="#101b42"
            />
              </Box>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

export default Statistics;