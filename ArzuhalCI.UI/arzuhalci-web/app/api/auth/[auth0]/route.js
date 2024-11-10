import { handleAuth, handleCallback, handleLogin } from '@auth0/nextjs-auth0';

const  afterCallback = async (req, session, state) => {
    console.log("User Session: ", session);
    console.log("State", state);
    try {      
        await fetch(`http://localhost:3001/api/customers`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',                
                'Authorization': `Bearer ${session.accessToken}`
            },
            body: JSON.stringify({
                name: `${session.user.given_name} ${session.user.family_name}`,
                email: session.user.email,
                identityId: session.user.sub
            })
        });

      return session;
    } catch (error) {
      console.error('Authorization bilgileri alınamadı', error);
      return session; // Hata olsa da mevcut session'u döndürelim
    }
  }

export const GET = handleAuth({
    callback: handleCallback({ afterCallback })
  });