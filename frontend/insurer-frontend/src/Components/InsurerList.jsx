import useInsurer from "../hook/useInsurer";
import InsurerCard from "./InsurerCard";
import { Grid, Box } from "@mui/material";

const InsurerList = () => {
  const { insurers } = useInsurer();

  return (
    <>
      {insurers.length ? (
        <Box
          sx={{
            backgroundColor: "#f5f5f5",
            padding: "1rem",
            borderRadius: "0.5rem",
            boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
          }}
        >
          <Grid container justifyContent="center" spacing={2}>
            {insurers.map((insurer) => (
              <Grid item xs={12} md={4} key={insurer.id}>
                <InsurerCard insurer={insurer} />
              </Grid>
            ))}
          </Grid>
        </Box>
      ) : (
        <h2>No hay aseguradoras disponibles.</h2>
      )}
    </>
  );
};

export default InsurerList;
