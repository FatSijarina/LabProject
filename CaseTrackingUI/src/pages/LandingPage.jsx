import React from 'react';
import { styled } from '@mui/system';
import { Container, Typography, Button, Grid } from '@mui/material';
import { Link } from 'react-router-dom';

const LandingContainer = styled('div')({
  color: '#00176A',
  padding: '20px 0',
});

const Section = styled('div')({
  padding: '40px 0',
});

const FeatureIcon = styled(Typography)({
  fontSize: '3rem',
  marginBottom: '16px',
});

const ActionButton = styled(Button)({
  backgroundColor: '#C8D4FF',
  color: '#00176A',
  '&:hover': {
    backgroundColor: '#AABDFE',
  },
});

const LandingPage = () => {
  return (
    <LandingContainer>
      <Container>
        <Section>
          <Typography variant="h3" marginBottom="16px">
            Welcome to Case Management System
          </Typography>
          <Typography variant="body1" textAlign="center">
            Manage your cases efficiently with our powerful case management system.
          </Typography>
          <ActionButton variant="contained" sx={{ marginTop: '20px' }}>
            Get Started
          </ActionButton>
        </Section>

        <Section>
          <Typography variant="h4" marginBottom="20px">
            Features
          </Typography>
          <Grid container spacing={4}>
            <Grid item xs={12} md={4}>
              <FeatureIcon>📂</FeatureIcon>
              <Typography variant="h6">Organize Your Cases</Typography>
              <Typography variant="body2">
                Easily create, manage, and categorize your cases for better organization and collaboration.
              </Typography>
            </Grid>
            <Grid item xs={12} md={4}>
              <FeatureIcon>🔍</FeatureIcon>
              <Typography variant="h6">Powerful Search</Typography>
              <Typography variant="body2">
                Quickly find and retrieve specific cases using advanced search and filtering options.
              </Typography>
            </Grid>
            <Grid item xs={12} md={4}>
              <FeatureIcon>📊</FeatureIcon>
              <Typography variant="h6">Analytics Dashboard</Typography>
              <Typography variant="body2">
                Visualize case data and trends with interactive charts and graphs to make informed decisions.
              </Typography>
            </Grid>
          </Grid>
        </Section>

        <Section>
          <Typography variant="h4" marginBottom="20px">
            Get Started Today
          </Typography>
          <Typography variant="body2">
            Join us and revolutionize the way you manage cases. Experience the efficiency and convenience of our
            Case Management System.
          </Typography>
          <Link to="register">
              <ActionButton variant="contained" sx={{ marginTop: '20px' }}>
                Sign Up
              </ActionButton>
            </Link>
        </Section>
      </Container>
    </LandingContainer>
  );
};

export default LandingPage;